import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SearchRoutingModule } from './search-routing.module';
import { SearchComponent } from './search.component';
import { SearchFilterComponent } from './components/search-filter/search-filter.component';
import { SearchResultComponent } from './components/search-result/search-result.component';


@NgModule({
  declarations: [SearchComponent, SearchFilterComponent, SearchResultComponent],
  imports: [
    CommonModule,
    SearchRoutingModule
  ]
})
export class SearchModule { }
