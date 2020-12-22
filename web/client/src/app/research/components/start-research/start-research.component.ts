import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { Router, ActivatedRoute } from '@angular/router';

import { NotifyService } from 'src/app/shared/services/notify.service';
import { ResearchService } from '../../../shared/services/research.service';

import { InitiateResponse } from '../../models/initiate-response';
import { InitiateResearch } from '../../models/initiate-research';
import { StartResearchRequest } from '../../models/start-research-request';
import { ResearchTemplate } from '../../models/research-template';
import { VendorService } from 'src/app/shared/services/vendor.service';
import { PriorResearchSummary } from '../../models/prior-research-summary';
import { StartResearchResult } from './models/start-research-result';
import { SustainmentVendorResult } from './models/sustainment-vendor-result';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-start-research',
  templateUrl: './start-research.component.html',
  styleUrls: ['./start-research.component.css']
})
export class StartResearchComponent implements OnInit, OnDestroy {

  constructor(
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private notifyService: NotifyService,
    private researchService: ResearchService,
    private vendorService: VendorService, //    private window: Window
  ) {
    // this is the data from the research-dashboard from the initiate research component
    this.initiateModel = this.userService.data;
  }

  private subscriptions = new Subscription();

  startResearchResult: StartResearchResult;
  initiateModel: InitiateResearch;
  isReinitiating = false;

  showVendors = false;
  showPriorResearch = false;

  srButtonActive = true;

  defaultResults: InitiateResponse = {
    modelHash: '',
    initiateSummary: {
      nsn: 'N/A',
      itemQuantity: 0,
      itemEstimatedValue: 0,
      estimatedValue: 0,
      serviceTypeName: 'N/A',
      sourceTypeName: 'N/A',
      purchaseRequestProcessingSystemId: 'Waiting for data',
    },
    initiateNsn: {
      nsn: 'Waiting for data',
      fsgName: 'Waiting for data',
      fscName: 'Waiting for data',
      name: 'Waiting for data',
      mmac: 'Waiting for data'
    },
    proposedBidType: 1,
    awards: [],
    suggestedVendors: [],
    priorResearchSummaries: [],
    proposedTemplates: [],
    remainingTemplates: [],
    searchQueueResponse: {
      requestId: 'Waiting for data',
      processMessage: 'Waiting for data',
      processStatusDescription: 'Waiting'
    }
  };

  results: InitiateResponse;

  partOwnerCount: number;
  vendorCount = 0;
  priorResearchCount = 0;

  selectedTemplate: ResearchTemplate;

  showInitiate = true;
  showFeedbackModal = false;
  feedback: string;

  dataLoaded = false;
  vendorDataLoaded = false;
  vendorSearchLoaded = false;

  resultsPerPage = 10;

  allSearchResults = [];
  currentPageResults = [];

  currentPage = 1;
  totalPages: number;
  pageNumberArray: number[] = [];

  ngOnInit(): void {
    this.results = this.defaultResults;

    // if there's data in the initiateModel, that means a Initiate Search was used
    if (this.initiateModel != null) {
      this.isReinitiating = true;
      this.start();
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  start(): void {
    this.dataLoaded = false;
    this.getInitiateResults(this.initiateModel);

    this.isReinitiating = false;
    this.initiateModel = null;
  }

  getTotalPages(): number {
    const totalResults = this.allSearchResults.length;
    const overflow = totalResults % 10 > 0;

    if (overflow) {
      return Math.trunc(totalResults / 10) + 1;
    } else {
      return totalResults / 10;
    }
  }

  getPageNumberArray(totalPages: number): number[] {
    // arrays are objects, the 'key' is the index. So array[0] is the same as object[propertyName]
    return [...Array(totalPages).keys()];
  }

  updateCurrentPageResults(): void {

    if (this.currentPage !== 1) {
      this.currentPageResults =
      this.allSearchResults.slice(this.currentPage * this.resultsPerPage - this.resultsPerPage, this.currentPage * this.resultsPerPage);
    } else {
      this.currentPageResults = this.allSearchResults.slice(0, this.currentPage * this.resultsPerPage);
    }
  }


  getInitiateResults(initiateQuery: InitiateResearch): void {

    this.subscriptions.add(
      this.researchService.getInitiateResults(initiateQuery).subscribe(res => {
        this.results = res;

        // only time the queue response is null, is the best case scenario
        if (this.results.searchQueueResponse === null) {
          this.partOwnerCount = this.results.awards.length;
          this.priorResearchCount = this.results.priorResearchSummaries.length;

        } else {
          this.partOwnerCount = 0;
          this.priorResearchCount = 0;
        }

        this.allSearchResults = res.suggestedVendors;

        this.vendorCount = this.allSearchResults.length;

        this.totalPages = this.getTotalPages();
        this.pageNumberArray = this.getPageNumberArray(this.totalPages);

        this.updateCurrentPageResults();

        this.vendorDataLoaded = true;
        this.vendorSearchLoaded = true;

        this.allSearchResults.forEach((vendor) => {

          while (vendor.sustainmentVendorId.length < 9) {
            vendor.sustainmentVendorId = '0' + vendor.sustainmentVendorId;
          }
        });

        this.dataLoaded = true;
      })
    
    );
  
  }

  // this is to handle the 'initiate' event that gets emitted from re-initiating with new results
  onInitiate(model: InitiateResearch): void {
    this.allSearchResults = [];
    this.currentPageResults = [];
    this.currentPage = 1;
    this.vendorCount = 0;
    this.totalPages = undefined;
    this.pageNumberArray = [];
    this.vendorDataLoaded = false;
    this.vendorSearchLoaded = false;

    this.initiateModel = model;
    this.isReinitiating = true;
    this.userService.data = null;
    this.start();
  }

  cancelInitate(): void {
    this.isReinitiating = false;
  }

  hasClaim(claim: number): boolean {
    return this.userService.hasClaim(claim);
  }

  toggleVendors(): void {
    if (this.vendorCount > 0) {

      if (this.showVendors) {
        this.showVendors = false;
      } else {

        // this prevents the styling to change if there's no results
        if (this.priorResearchCount > 0) { this.showPriorResearch = false; }

        this.showVendors = true;
      }
    }
  }

  togglePriorResearch(): void {

    if (this.priorResearchCount > 0) {

      if (this.showPriorResearch) {
        this.showPriorResearch = false;
      } else {

        // this prevents the styling to change if there's no results
        if (this.vendorCount > 0) { this.showVendors = false; }

        this.showPriorResearch = true;
      }
    }
  }

  // checks to make sure everything is good to go before starting research, notifies user if anything is wrong
  check_start_reqs(): void {

    this.toggle_sr_button();

    if (this.userService.hasClaim(5)) {

      // check if template was selected
      if (this.selectedTemplate) {
        this.start_research();
      } else {
        this.deny('No Template Selected');
      }

    } else {
      this.deny('Incorrect Permissions');
    }

  }

  // starts the research process
  start_research(): void {
    this.notifyService.show('Starting Research', {classname: 'alert-info'});

    const srRequest: StartResearchRequest = {
      initiateResponse: this.results,
      formTemplate: this.selectedTemplate,
      remainingTemplateReason: this.feedback
    };

    this.researchService.createTemplateInstance(srRequest).subscribe(res => {
      const id = res;
      this.router.navigate(['../template', id], {relativeTo: this.route});
    });

  }


  deny(errorMessage: string): void {
    this.notifyService.show(errorMessage, {classname: 'alert-danger'});
    this.toggle_sr_button();
  }

  toggle_sr_button(): void {
    if (this.srButtonActive) {
      this.srButtonActive = false;
    } else {
      this.srButtonActive = true;
    }
  }

  toggleShowInitiate(): void {
    this.showInitiate = !this.showInitiate;
  }

  nextPage(): void {
    if (this.currentPage !== this.totalPages) {
      this.currentPage = this.currentPage + 1;
    }

    this.updateCurrentPageResults();
  }

  previousPage(): void {
    if (this.currentPage !== 1) {
      this.currentPage = this.currentPage - 1;
    }

    this.updateCurrentPageResults();
  }

  lastPage(): void {
    this.currentPage = this.totalPages;
    this.updateCurrentPageResults();
  }

  firstPage(): void {
    this.currentPage = 1;
    this.updateCurrentPageResults();
  }

  jumpToPage(pageNumber: number): void {
    this.currentPage = pageNumber;
    this.updateCurrentPageResults();
  }

  navVendDetail(vendor: SustainmentVendorResult): void {

    const mrId = vendor.researchVendorId;
    const susId = vendor.sustainmentVendorId;

    const url = window.location.origin + '/vendor/detail/' + (mrId ?? susId) + '/' + susId;
    console.log('New window to ' + url);

    window.open(url, '_blank');
  }

  navToResearchDetail(research: PriorResearchSummary): void {
    const url = window.location.origin + '/research/template/' + research.templateInstanceId + (research.completionDate ? '/summary' : '');
    console.log('New window to ' + url);

    window.open(url, '_blank');
  }
}
