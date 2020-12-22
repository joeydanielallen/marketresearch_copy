import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared/shared.module';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { RecentPartsComponent } from './components/recent-parts/recent-parts.component';
import { InprogressResearchComponent } from './components/inprogress-research/inprogress-research.component';
import { NotificationsComponent } from './components/notifications/notifications.component';
import { RecentStrategiesComponent } from './components/recent-strategies/recent-strategies.component';
import { RecentResourcesComponent } from './components/recent-resources/recent-resources.component';


@NgModule({
  declarations: [
    DashboardComponent,
    RecentPartsComponent,
    InprogressResearchComponent,
    NotificationsComponent,
    RecentStrategiesComponent,
    RecentResourcesComponent],
  imports: [
    CommonModule,
    SharedModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
