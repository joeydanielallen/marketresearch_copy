import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResearchService } from '../../../shared/services/research.service';
import { TemplateInstanceService } from '../template-instance/template-instance.service';
import { NotifyService } from 'src/app/shared/services/notify.service';
import { UserService } from 'src/app/shared/services/user.service';
import { TemplateInstance } from 'src/app/research/models/template-instance';
import { VendorService } from 'src/app/shared/services/vendor.service';
import { SystemService } from 'src/app/shared/services/system.service';

import { ResearchFormVendor } from '../../models/research-form-vendor';
import { InitiateSummary } from '../../models/initiate-summary';
import { InitiateAward } from '../../models/initiate-award';
import { SustainmentVendorResult } from '../start-research/models/sustainment-vendor-result';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-form-summary',
  templateUrl: './form-summary.component.html',
  styleUrls: ['./form-summary.component.css']
})
export class FormSummaryComponent implements OnInit, OnDestroy {

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private researchService: ResearchService,
    private templateInstanceService: TemplateInstanceService,
    private notifyService: NotifyService,
    private userService: UserService, // private window: Window,
    private vendorService: VendorService,
    private appService: SystemService
  ) { }


  private subscriptions = new Subscription();

  readOnly = false;
  templateId: number;
  reOpening = false;
  userIsCreator = false;
  awards: InitiateAward[];
  vendorCount: number;
  isLoading = true;

  selectedVendors: ResearchFormVendor[] = [];
  selectedVendorsLoading = false;

  vendorDataLoaded = false;
  // vendorSearchLoaded = false;

  resultsPerPage = 10;

  allSearchResults = [];
  currentPageResults = [];

  currentPage = 1;
  totalPages: number;
  pageNumberArray: number[] = [];



  ngOnInit(): void {
    this.templateId = this.route.snapshot.params.id;

    this.getRecentTemplateInstance();
    this.getSelectedVendors(this.templateId);
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  isFormCompleted(): boolean {
    return this.templateInstanceService.templateInstance.completedOn !== null;
  }


  getSelectedVendors(templateInstanceId: number): void {

    this.selectedVendorsLoading = true;

    this.subscriptions.add(
      this.researchService.getVendorsAddedOnForm(templateInstanceId).subscribe(res => {
        this.selectedVendors = res;
        this.appService.log.debug('SELECTED VENDORS', res);
        this.selectedVendorsLoading = false;
      }, (e) => {
        this.notifyService.show('An error occurred. Please try again.', {classname: 'alert-danger'});
        this.appService.log.error('Error getting selected vendors', e);
        this.selectedVendors = [];
        this.selectedVendorsLoading = false;
      })
    );

  }



  getRecentTemplateInstance(): void {
    
    this.subscriptions.add(
      this.researchService.getTemplateInstance(this.templateId).subscribe((res) => {
        this.templateInstanceService.templateInstance = res;
        console.log(res);
        this.isLoading = false;

        if (!this.isFormCompleted()){
          this.navToForm();
          return;
        }

        // this has to be in here because it uses the nsn from the response
        // this.getSuggestedVendors();
        this.allSearchResults = res.suggestedVendors;
        this.vendorCount = this.allSearchResults.length;
        this.totalPages = this.getTotalPages();
        this.pageNumberArray = this.getPageNumberArray(this.totalPages);
        this.updateCurrentPageResults();

        this.checkTemplateInstancePermissions();

      }, (e) => {
        this.notifyService.show('An error occurred. Please try again.', {classname: 'alert-danger'});
        console.log(JSON.stringify(e));

        this.isLoading = false;
      })
    );


  }


  getTemplateInstance(): TemplateInstance {
    return this.templateInstanceService.templateInstance;
  }

  checkTemplateInstancePermissions(): void {

    const user = this.userService.userAccount;
    const creatorId = this.templateInstanceService.templateInstance.createdByAppUser.id;

    console.log(creatorId);

    if (user.userAccountId === creatorId) {
      this.userIsCreator = true;
    }

    // checks the acces right array for the form and grabs the index of the local user that matches
    //   the logged in user, if it doesn't exist then the user doesn't have access and -1 is returned
    const userIndex = this.templateInstanceService.templateInstance.appUsers.findIndex((localUser) => {
      return localUser.id === user.userAccountId;
    });

    if (user.userAccountId === creatorId || userIndex !== -1) {
      this.readOnly = false;
    } else {
      this.readOnly = true;
    }
  }

  reOpen(): void {

    this.reOpening = true;
    this.appService.notifier.showInfo('Re-Opening Research');

    this.researchService.completeResearch(this.templateInstanceService.templateInstance.id).subscribe((res) => {
      this.isLoading = true;
      this.navToForm();
      this.reOpening = false;
    }, (e) => {
      this.appService.notifier.showDanger('Error with Re-Opening');
    });

  }

  downloadPDF(): void {
    window.open(this.userService.originUrl + 'ResearchDownload/' + this.templateInstanceService.templateInstance.id, '_blank');
  }

  navToForm(): void {
    this.router.navigate(['..'], {relativeTo: this.route});
  }

  navVendDetail(vendor: SustainmentVendorResult): void {

    const mrId = vendor.researchVendorId;
    const susId = vendor.sustainmentVendorId;

    const url = window.location.origin + `/vendor/detail/${mrId ?? susId}/${susId}`;
    console.log('New window to ' + url);

    window.open(url, '_blank');
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
    // arrays are objects, the 'key' is the index. So array[0] is the same as object[0]
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

  jumpToPage(pageNumber): void {
    this.currentPage = pageNumber;
    this.updateCurrentPageResults();
  }
}
