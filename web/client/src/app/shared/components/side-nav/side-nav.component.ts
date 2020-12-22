import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {

  constructor(
    private userService: UserService) { }

  userIsLoggedIn = false;

  ngOnInit(): void {
    this.userService.loggedIn.subscribe((userAccount) => {
      this.userIsLoggedIn = userAccount !== null;
    });

    this.userIsLoggedIn = this.userService.userAccount !== null;
  }

}
