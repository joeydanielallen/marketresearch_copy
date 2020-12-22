import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ResearchService } from 'src/app/shared/services/research.service';
import { SystemService } from 'src/app/shared/services/system.service';

@Component({
  selector: 'app-inprogress-research',
  templateUrl: './inprogress-research.component.html',
  styleUrls: ['./inprogress-research.component.css']
})
export class InprogressResearchComponent implements OnInit, OnDestroy {

  private subscriptions = new Subscription();

  templateInstanceSummaries = [];
  isLoading = true;
  isError = false;

  constructor(
    private researchService: ResearchService,
    private router: Router,
    private appSvc: SystemService
  ) { }

  ngOnInit(): void {
    this.getTemplateInstanceSummaries();
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  getTemplateInstanceSummaries(): void {
    this.isError = false;

    this.subscriptions.add(
      this.researchService.getTemplateInstanceSummaries(true).subscribe((res) => {

        for (let i = 0; i < 3 && res[i]; i++){
          this.templateInstanceSummaries.push(res[i]);
        }

        this.isLoading = false;
      }, err => {
        this.appSvc.log.error('Error loading research in progress', err);
        this.isLoading = false;
        this.isError = true;
      })
    );


  }

  navToTemplateInstance(id: string) {
    this.router.navigate([`/research/template/${id}`]);
  }
}
