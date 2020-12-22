import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared/shared.module';

import { ResearchRoutingModule } from './research-routing.module';
import { NgSelectModule } from '@ng-select/ng-select';

import { ResearchComponent } from './research.component';
import { InitiateResearchComponent } from './components/initiate-research/initiate-research.component';
import { MyResearchComponent } from './components/research-dashboard/components/my-research/my-research.component';
import { SearchResearchComponent } from './components/research-dashboard/components/search-research/search-research.component';
import { ResearchDashboardComponent } from './components/research-dashboard/research-dashboard.component';
import { StartResearchComponent } from './components/start-research/start-research.component';
import { FilterPipe } from './components/research-dashboard/components/my-research/filter.pipe';
import { TemplateInstanceComponent } from './components/template-instance/template-instance.component';
import { QuestionsComponent } from './components/template-instance/components/questions/questions.component';
import { SectionsComponent } from './components/template-instance/components/sections/sections.component';
import { FormSummaryComponent } from './components/form-summary/form-summary.component';
import { SummaryInfoComponent } from './components/form-summary/components/summary-info/summary-info.component';
import { ResearchTeamComponent } from './components/form-summary/components/research-team/research-team.component';


@NgModule({
  declarations: [
    ResearchComponent,
    InitiateResearchComponent,
    MyResearchComponent,
    SearchResearchComponent,
    ResearchDashboardComponent,
    StartResearchComponent,
    FilterPipe,
    TemplateInstanceComponent,
    QuestionsComponent,
    SectionsComponent,
    FormSummaryComponent,
    SummaryInfoComponent,
    ResearchTeamComponent, ],
  imports: [
    CommonModule,
    SharedModule,
    ResearchRoutingModule,
    NgSelectModule
  ]
})
export class ResearchModule { }
