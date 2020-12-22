import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared/shared.module';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorComponent } from './vendor.component';
import { VendorDetailComponent } from './components/vendor-detail/vendor-detail.component';
import { VendorInformationComponent } from './components/vendor-detail/components/vendor-information/vendor-information.component';
import { VendorNotesComponent } from './components/vendor-detail/components/vendor-notes/vendor-notes.component';
import { VendorContactsComponent } from './components/vendor-detail/components/vendor-contacts/vendor-contacts.component';
import { FormsModule } from '@angular/forms';
import { VendorSearchComponent } from './components/vendor-search/vendor-search.component';
import { VendorNamesComponent } from './components/vendor-detail/components/vendor-names/vendor-names.component';
import { VendorLocationsComponent } from './components/vendor-detail/components/vendor-locations/vendor-locations.component';
import { VendorTypesComponent } from './components/vendor-detail/components/vendor-types/vendor-types.component';
import { ZipPipe } from './components/vendor-detail/components/vendor-locations/zip.pipe';
import { VendorManufacturingComponent } from './components/vendor-detail/components/vendor-manufacturing/vendor-manufacturing.component';
import { VendorIndustryComponent } from './components/vendor-detail/components/vendor-industry/vendor-industry.component';
import { VendorCertificationComponent } from './components/vendor-detail/components/vendor-certification/vendor-certification.component';
import { VendorInfoShortComponent } from './components/vendor-detail/components/vendor-info-short/vendor-info-short.component';


@NgModule({
  declarations: [
    VendorComponent,
    VendorDetailComponent,
    VendorInformationComponent,
    VendorNotesComponent,
    VendorContactsComponent,
    VendorSearchComponent,
    VendorNamesComponent,
    VendorLocationsComponent,
    VendorTypesComponent,
    ZipPipe,
    VendorManufacturingComponent,
    VendorIndustryComponent,
    VendorCertificationComponent,
    VendorInfoShortComponent
  ],
  imports: [
    CommonModule,
    VendorRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class VendorModule { }
