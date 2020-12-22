import { Component, OnInit } from '@angular/core';
import { TemplateInstanceService } from '../../../template-instance/template-instance.service';

@Component({
  selector: 'app-research-team',
  templateUrl: './research-team.component.html',
  styleUrls: ['./research-team.component.css']
})
export class ResearchTeamComponent implements OnInit {

  constructor(
    private templateInstanceService: TemplateInstanceService
  ) { }

  ngOnInit(): void {
  }

  getTemplateInstance() {
    return this.templateInstanceService.templateInstance;
  }

}
