import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../../../shared/services/user.service';
import { InitiateResearch } from '../../models/initiate-research';

@Component({
  selector: 'app-research-dashboard',
  templateUrl: './research-dashboard.component.html',
  styleUrls: ['./research-dashboard.component.css']
})
export class ResearchDashboardComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService
  ) { }


    showInitiate = false;



  ngOnInit(): void {
  }

  hasClaim(claim: number): boolean {
    return this.userService.hasClaim(claim);
  }

  // when someone clicks the 'Initiate' button saves the data to the 'userService' and navigates to the start page
  onInitiate(model: InitiateResearch): void {
    this.userService.data = model;
    this.router.navigate(['start'], { relativeTo: this.route });
  }


  toggleShowInitiate(): void {
    this.showInitiate = !this.showInitiate;
  }

}
