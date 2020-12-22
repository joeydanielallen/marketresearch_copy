import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { UserService } from './shared/services/user.service';
import { Inject } from '@angular/core';
import { WINDOW } from './shared/window-provider';
import { filter } from 'rxjs/operators';
import { Event as NavigationEvent } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  userLoggedIn = false;
  isValidating = true;
  isRoutingToLogin = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    @Inject(WINDOW) private window: Window,
    private userService: UserService) {
      router.events.pipe(
          filter(( event: NavigationEvent ) => {
            return ( event instanceof NavigationEnd );
          })
        )
        .subscribe(( event: NavigationEnd ) => {
            if (!this.userService.isLoggedIn() && event.url !== '/login') {
              this.isRoutingToLogin = true;
              this.router.navigate(['/login']);
            }
          });

      this.userService.initializedUrl = this.window.location.pathname;
      this.userService.originUrl = this.window.location.origin.replace('http:', 'https:').replace('4200', '44382') + '/api/';

      // console.log('Initialized URL ' + this.userService.initializedUrl);

      if (this.userService.isLoggedIn()) {
        this.isValidating = false;
      } else {
        this.isValidating = false;
        this.router.navigate(['/login']);
      }
    }

  ngOnInit() {
    if (this.userService.isLoggedIn()) {
      this.userLoggedIn = true;
    } else {
      this.userLoggedIn = false;
    }
  }
}
