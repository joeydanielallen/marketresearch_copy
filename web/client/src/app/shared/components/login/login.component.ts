import { AfterContentInit, AfterViewInit, Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { UserService } from '../../services/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { LoginModel } from './login-model';
import { UserAccount } from '../../models/user-account';
import { SystemService } from '../../services/system.service';
import { RoleLogin } from './models/role-login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, AfterContentInit {

  constructor(
    private router: Router,
    private userService: UserService,
    private appSvc: SystemService) {
      this.showLoginDropdown =
      window.location.href.indexOf('localhost') > -1 ||
      window.location.href.indexOf('marketresearch.azure') > -1 ;
    }

    loginModel = new LoginModel();
    errorMsg = '';
    isLoggingIn = false;

    focusEmail = false;
    focusPassword = false;

    showLoginDropdown = false;
    devLoginList = [
      new RoleLogin(2, 'support@email.com', 'Admin'),
      new RoleLogin(3, 'loggie421@email.com', '421st Logistician'),
      new RoleLogin(4, 'engineer421@email.com', '421st Engineer'),
      new RoleLogin(5, 'loggie422@email.com', '422nd Logistician'),
      new RoleLogin(6, 'engineer422@email.com', '422nd Engineer')
    ];

  ngOnInit(): void {
    if (this.userService.isLoggedIn()) {
      this.router.navigate(['/dashboard']);
    }
  }

  ngAfterContentInit(): void {
     this.emailFocus();
   }

   isLoggedIn(): boolean {
     return this.userService.isLoggedIn();
   }

  selectUserRole(roleLogin: RoleLogin): void {
    this.loginModel.username = roleLogin.login;
    this.loginModel.password = 'password';
  }

  onKeyEnter(event: KeyboardEvent): void {
    if (event.key === 'Enter') {
      this.logIn();
    }
  }

  logIn(): void {
    if (this.isLoggingIn) {
      return;
    }

    this.isLoggingIn = true;
    this.errorMsg = '';

    if (!this.validateInput()) {
      this.isLoggingIn = false;
      return;
    }

    this.userService.getUserAccount(
      this.loginModel.username,
      this.loginModel.password
    ).subscribe((userAccount: UserAccount) => {
      this.isLoggingIn = false;

      this.userService.persistUserAccount(userAccount, this.loginModel.rememberUser);

      if (this.userService.initializedUrl !== '' &&
          this.userService.initializedUrl !== '/' &&
          this.userService.initializedUrl !== '/login') {

        this.router.navigate([this.userService.initializedUrl]);
        return;

      } else {
        this.router.navigate(['/dashboard']);
        return;
      }

    },
    (error: HttpErrorResponse) => {
      this.isLoggingIn = false;
      if (error.status === 404) {
        this.errorMsg = 'Email and Password combination not found.';
      } else {
        this.appSvc.log.error('Error calling login service. ', error);
        if (!error.ok &&
          error.status === 0 &&
          error.message.indexOf('0 Unknown Error') > -1) {
            this.errorMsg = 'An error occurred sending data. Ensure network connectivity, and contact your system admin.';
        }
        else {
          this.errorMsg = 'Unknow error occurred. Try again or contact the system admin.';
        }
      }
    });
  }

  private validateInput(): boolean {
    if (this.loginModel.username.length < 1) {
      this.errorMsg = 'No Email entered';
      return false;
    } else if (this.loginModel.password.length < 1) {
      this.errorMsg = 'No Password entered';
      return false;
    }

    return true;
  }

  emailFocus(): void {
    this.focusEmail = true;
  }

  emailUnFocus(): void {
    this.focusEmail = false;
  }


  passwordFocus(): void {
    this.focusPassword = true;
  }


  passwordUnFocus(): void {
    this.focusPassword = false;
  }


}
