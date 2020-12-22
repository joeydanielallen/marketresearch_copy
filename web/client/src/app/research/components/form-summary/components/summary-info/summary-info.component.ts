import { Component, OnInit } from '@angular/core';
import { TemplateInstanceService } from '../../../template-instance/template-instance.service';

@Component({
  selector: 'app-summary-info',
  templateUrl: './summary-info.component.html',
  styleUrls: ['./summary-info.component.css']
})
export class SummaryInfoComponent implements OnInit {

  constructor(
    private templateInstanceService: TemplateInstanceService
  ) { }

  daysToComplete: number;

  ngOnInit(): void {
    this.getTimeToComplete();
  }

  getTemplateInstance() {
    return this.templateInstanceService.templateInstance;
  }

  getTimeToComplete(): void {

    const startDate = new Date(this.templateInstanceService.templateInstance.createdOn);
    const endDate = new Date(this.templateInstanceService.templateInstance.completedOn);

    const timeDifference = endDate.getTime() - startDate.getTime();

    const daysDifference = Math.floor(timeDifference / (60 * 60 * 24 * 1000));

    this.daysToComplete = daysDifference;

  }

}
