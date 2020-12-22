import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';

import { RecentVendorsComponent } from './components/recent-vendors/recent-vendors.component';

import { WINDOW_PROVIDER } from './window-provider';
import { HttpAuthInterceptor } from './inteceptors/http-auth-interceptor';

@NgModule({
  declarations: [
    RecentVendorsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    NgbToastModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    NgbToastModule,
    RecentVendorsComponent
  ],
  providers: [
    WINDOW_PROVIDER,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpAuthInterceptor,
      multi: true
    }
  ],
})
export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: []
    };
  }
 }
