import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ResearchDashboardComponent } from './components/research-dashboard/research-dashboard.component';
import { StartResearchComponent } from './components/start-research/start-research.component';
import { TemplateInstanceComponent } from './components/template-instance/template-instance.component';
import { ResearchComponent } from './research.component';
import { FormSummaryComponent } from './components/form-summary/form-summary.component';

const routes: Routes = [
  {  path: '', component: ResearchComponent,
    children: [
      {
        path: '',
        children: [

          { path: '', component: ResearchDashboardComponent },
          { path: 'start', component: StartResearchComponent },
          { path: 'template/:id', component: TemplateInstanceComponent },
          { path: 'template/:id/summary', component: FormSummaryComponent }
        ]
      },

    ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResearchRoutingModule { }
