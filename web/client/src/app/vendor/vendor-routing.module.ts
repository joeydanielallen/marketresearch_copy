import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// import { VendorComponent } from './vendor.component';
import { VendorDetailComponent } from './components/vendor-detail/vendor-detail.component';
import { VendorSearchComponent } from './components/vendor-search/vendor-search.component';

const routes: Routes = [
  { path: 'detail/:mrId/:susId', component: VendorDetailComponent },
  { path: 'search', component: VendorSearchComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
