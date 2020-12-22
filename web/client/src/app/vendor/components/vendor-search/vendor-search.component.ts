import { Component, OnInit, OnDestroy } from '@angular/core';
import { VendorService } from '../../../shared/services/vendor.service';
import { NotifyService } from 'src/app/shared/services/notify.service';
import { Router } from '@angular/router';
import { SystemService } from 'src/app/shared/services/system.service';
import { Subscription } from 'rxjs';

import { SustainmentVendorResult } from 'src/app/research/components/start-research/models/sustainment-vendor-result';
import {ResearchVendorDetail, ResearchVendorDetail as ResearchVendorResult } from '../vendor-detail/models/research-vendor/research-vendor-detail';

@Component({
  selector: 'app-vendor-search',
  templateUrl: './vendor-search.component.html',
  styleUrls: ['./vendor-search.component.css']
})
export class VendorSearchComponent implements OnInit, OnDestroy {

  constructor(
    private vendorService: VendorService,
    private notifyService: NotifyService,
    private router: Router,
    private appService: SystemService
  ) { }

  private validationSubscriptions: Subscription = new Subscription();
  private searchSubscription: Subscription = new Subscription();

  searchText = '';

  resultsPerPage = 7;

  allSearchResults = [];
  currentPageResults = [];

  currentPage = 1;
  totalPages: number;
  pageNumberArray: number[] = [];

  currentFilter = 'Name';

  searching = false;

  validating: boolean;

  showFilters = true;

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.validationSubscriptions.unsubscribe();
    this.searchSubscription.unsubscribe();
  }



  search(): void {
    
    this.searchSubscription.unsubscribe();
    this.validationSubscriptions.unsubscribe();

    this.searchSubscription = new Subscription();

    
    if (this.searchText !== '') {
      this.clearPreviousSearchResults();
      this.searching = true;

      if (this.currentFilter === 'NSN') {

        this.searchSubscription.add(
          
          this.vendorService.searchVendorsByNSN(this.searchText).subscribe(res => {
            console.log(res);
            this.allSearchResults = res;

            this.allSearchResults.forEach((vendor) => {

              while (vendor.sustainmentVendorId.length < 9) {
                vendor.sustainmentVendorId = '0' + vendor.sustainmentVendorId;
              }

            });

            console.log(this.allSearchResults);

            this.searching = false;

            this.totalPages = this.getTotalPages();
            this.pageNumberArray = this.getPageNumberArray(this.totalPages);

            this.updateCurrentPageResults();
            this.validateVendors('SUS');

          }, error => {
            if (error.status !== 500) {
              this.appService.notifier.showDanger(error.error);
              this.appService.log.error('VENDOR SEARCH BY NSN', error);

            } else {
              this.appService.notifier.showDanger('Error, try again');
              this.appService.log.error('VENDOR SEARCH BY NSN', error);
            }

            this.searching = false;

          })


          );


      } else {

        this.searchSubscription.add(

          this.vendorService.searchVendorsByOther(this.searchText).subscribe(res => {
            console.log(res);

            this.allSearchResults = res;
            this.searching = false;

            this.totalPages = this.getTotalPages();
            this.pageNumberArray = this.getPageNumberArray(this.totalPages);

            this.updateCurrentPageResults();
            this.validateVendors('MR');

          }, error => {
            if (error.status !== 500) {
              this.appService.notifier.showDanger(error.error);
              this.appService.log.error('VENDOR SEARCH BY NSN', error);

            } else {
              this.appService.notifier.showDanger('Error, try again');
              this.appService.log.error('VENDOR SEARCH BY NSN', error);
            }

            this.searching = false;

          })
      


        )
  
      }

    } else {
      this.notifyService.show('Search Text Empty', {classname: 'alert-danger'});
    }


  }


  validateVendors(vendorType: string): void {

    this.validating = true;

    if (vendorType === 'SUS') {

      this.allSearchResults.forEach(vendor => {
        vendor.valid = undefined;

        if (vendor.sustainmentVendorId !== 'null') {

          if (this.validationSubscriptions.closed) {
            this.validationSubscriptions = new Subscription();
          }


          this.validationSubscriptions.add(
            this.vendorService.getSustainmentVendorDetails(vendor.sustainmentVendorId).subscribe(res => {
              vendor.valid = res.names.profile === null ? false : true;
            })
          );
        }

      });

    } else {

      this.allSearchResults.forEach(vendor => {
        vendor.valid = undefined;

        if (vendor.sustainmentId !== 'null') {

          if (this.validationSubscriptions.closed) {
            this.validationSubscriptions = new Subscription();
          }

          this.validationSubscriptions.add(
            this.vendorService.getSustainmentVendorDetails(vendor.sustainmentId).subscribe(res => {
              vendor.valid = res.names.profile === null ? false : true;
            })
          );

        }

      });

    }


  }



  clearPreviousSearchResults(): void {
    this.allSearchResults = [];
    this.currentPageResults = [];
    this.currentPage = 1;
    this.totalPages = undefined;
    this.pageNumberArray = [];
  }

  // updates templates and styling on filter buttons
  selectButton(event): void {

    this.clearPreviousSearchResults();
    this.searchText = '';

    // the event.target.id is the id on the HTML tag for the button
    if (event.target.id === 'NSN') {

      // updates the currentFilter variable since the styling is based on it
      this.currentFilter = 'NSN';

    } else if (event.target.id === 'Name') {
      this.currentFilter = 'Name';

    } else if (event.target.id === 'Cage') {
      this.currentFilter = 'Cage';

    } else if (event.target.id === 'Duns') {
      this.currentFilter = 'Duns';

    }
  }

  onKeySearch(event: KeyboardEvent): void {
    if (event.key === 'Enter') {
      this.search();
    }
  }

  validateNSN(): string {

    let errorMsg = '';

    if (!this.searchText || this.searchText.length < 3) {
      errorMsg = 'Invalid NSN/Service/Part number';
    }

    return errorMsg;
  }



  getTotalPages(): number {
    const totalResults = this.allSearchResults.length;
    const overflow = totalResults % this.resultsPerPage > 0;

    if (overflow) {
      return Math.trunc(totalResults / this.resultsPerPage) + 1;
    } else {
      return totalResults / this.resultsPerPage;
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

  jumpToPage(pageNumber: number): void {
    this.currentPage = pageNumber;
    this.updateCurrentPageResults();
  }



  isResearchVendorResult(vendor: ResearchVendorResult | SustainmentVendorResult): vendor is ResearchVendorResult {
    return (vendor as ResearchVendorResult).id !== undefined;
  }

  navVendDetail(vendor: any): void {
    
    let mrId: number;
    let susId: string;

    if (!this.validationSubscriptions.closed) {
      this.validationSubscriptions.unsubscribe();
    }

    if (this.isResearchVendorResult(vendor)) {
      // only MR Vendor has .id property
      mrId = vendor.id;
      susId = vendor.sustainmentId
    } else {
      mrId = vendor.researchVendorId
      susId = vendor.sustainmentVendorId
    }

    this.router.navigate([ `/vendor/detail/${mrId ?? susId}/${susId}`]);

  }



  toggleShowFilters(): void {
    this.showFilters = !this.showFilters;
  }







}
