import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { UserService } from '../../services/user.service';
import { UserClaims } from '../../models/user-claims';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit {

  constructor(
    private router: Router,
    private userService: UserService) { }

  isValidating = true;
  userIsLoggedIn = false;
  userName = '';

  ngOnInit(): void {
    this.userService.loggedIn.subscribe((userAccount) => {
      this.userIsLoggedIn = userAccount !== null;
      if (userAccount) {
        this.userName = userAccount.firstName + ' ' + userAccount.lastName;
      }
    });
    this.userIsLoggedIn = this.userService.userAccount !== null;
    if (this.userService && this.userService.userAccount) {
      this.userName = this.userService.userAccount.firstName + ' ' +
        this.userService.userAccount.lastName;
    }
  }

  hasClaim(claim: number): boolean {
    return this.userService.hasClaim(claim);
  }

  hasAnyClaim(claims: number[]): boolean {
    return this.userService.hasAnyClaim(claims);
  }

  logout(): void {
    this.userService.logout();
    this.router.navigate(['/login']);
  }


  isLoginPage(): boolean {
    let isLoginPage = false;

    if (this.router.url === '/login') {
      isLoginPage = true;
    }

    return isLoginPage;
  }

  getUserInitials(): string {
    return this.userService?.userAccount?.firstName[0] + ' ' + this.userService?.userAccount?.lastName[0];
  }

}
