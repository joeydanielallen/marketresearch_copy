import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Inject } from '@angular/core';
import { WINDOW } from '../../../../../shared/window-provider';

import { ClipBoardService } from '../../../../../shared/services/clip-board.service';
import { NotifyService } from 'src/app/shared/services/notify.service';

import { TemplateInstanceSummary } from 'src/app/research/models/my-research';
import { UserService } from 'src/app/shared/services/user.service';
import { ResearchService } from 'src/app/shared/services/research.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-my-research',
  templateUrl: './my-research.component.html',
  styleUrls: ['./my-research.component.css']
})



export class MyResearchComponent implements OnInit, OnDestroy {

  constructor(
    private clip: ClipBoardService,
    private router: Router,
    private notifyService: NotifyService,
    private userService: UserService,
    private researchService: ResearchService,
    @Inject(WINDOW) private window: Window
  ) { }

  private subscriptions = new Subscription();

  // starts default filter for templates on all
  currentFilter = 'working'; // 'all';

  allTemplates: TemplateInstanceSummary[] = [];
  showingTemplates: TemplateInstanceSummary[] = [];
  searchText: string;
  isLoading = true;


  ngOnInit(): void {
    this.getTemplateInstanceSummaries();
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }


  // gets the user's templates from the backend
  getTemplateInstanceSummaries(): void {

    // returns array for templates
    this.subscriptions.add(
      this.researchService.getTemplateInstanceSummaries().subscribe((res) => {

        // gets all templates
        this.allTemplates = res;

        // sets showing templates to all templates
        this.showingTemplates = res;

        this.isLoading = false;
        this.filterByWorking();

      }, (e) => {
        this.isLoading = false;
        this.notifyService.show('An error occurred. Please try again.', {classname: 'alert-danger'});
      })
    );


  }

  filterByWorking(): void {
    if (this.isLoading) { return; }

    this.currentFilter = 'working';
    this.showingTemplates = this.allTemplates.filter( template =>
        template.completedOnUtc === null
      );
  }

  filterByCompleted(): void {
    if (this.isLoading) { return; }

    this.currentFilter = 'completed';
    this.showingTemplates = this.allTemplates.filter( template =>
      template.completedOnUtc != null
    );
  }

  removeFilters(): void {
    if (this.isLoading) { return; }

    this.currentFilter = 'all';
    this.showingTemplates = this.allTemplates;
  }

  // function to copy link to template to clipboard
  copyTemplateLink(id: string): void {
    try {

      // starting mock nav link just to have something, in the future will be route of form to edit/view it
      const prefix = this.window.location.origin + '/research/template/';

      // adds the templates unique id
      const link = prefix + id;

      this.clip.copyToClipboard(link);
      this.notifyService.show('Link Copied!', {classname: 'alert-success'});

    } catch (e) {
      this.notifyService.show('Error Copying Link.', {classname: 'alert-danger'});
      console.log('Error copying link: ' + e);
    }
  }

  // navigate to the selected template
  openTemplate(id: number, completedOn: Date): void {

    if (completedOn) {
      this.router.navigate([`/research/template/${id}/summary`]);
    } else {
      // navigating to the form and adding it's id to the url params
      this.router.navigate([`/research/template/${id}`]);
    }
  }
}
