import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { InitiateResearch } from 'src/app/research/models/initiate-research';
import { KeyValue } from 'src/app/shared/models/key-value';
import { NotifyService } from 'src/app/shared/services/notify.service';

@Component({
  selector: 'app-initiate-research',
  templateUrl: './initiate-research.component.html',
  styleUrls: ['./initiate-research.component.css']
})
export class InitiateResearchComponent implements OnInit {

  @Output() initiated = new EventEmitter<InitiateResearch>();
  @Input() initialInitiateModel: InitiateResearch;
  @Input() isDisabled: boolean;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private notifyService: NotifyService
  ) { }

  initiateModel: InitiateResearch;
  serviceItems = [ new KeyValue(1, 'Buy'), new KeyValue(2, 'Repair')];
  sourceItems = [new KeyValue(1, 'Domestic'), new KeyValue(2, 'Foreign')];
  errorMsg = '';
  buttonText = 'Initiate';

  ngOnInit(): void {
    if (this.initialInitiateModel) {
      this.initiateModel = this.initialInitiateModel;
    } else {
      const model = new InitiateResearch();
      model.serviceType = 1;
      model.sourceType = 1;
      model.itemQuantity = 1;
      this.initiateModel = model;
    }

    if (this.router.url === '/research/start') { this.buttonText = 'Re-initiate'; }

  }

  validate(): boolean {
    this.errorMsg = '';
    if (!this.initiateModel.nsn ||
      this.initiateModel.nsn.length < 3) {
      this.errorMsg = 'Invalid NSN/Service/Part number';
      return false;
    }
    if (!this.initiateModel.purchaseRequestProcessingSystemId ||
      this.initiateModel.purchaseRequestProcessingSystemId.trim().length < 1) {
        this.errorMsg = 'Invalid PRPS Number';
        return false;
      }
    if (this.initiateModel.itemQuantity === undefined ||
      this.initiateModel.itemQuantity < 0) {
        this.errorMsg = 'Invalid Unit Quantity';
        return false;
    }
    if (this.initiateModel.itemEstimatedValue === undefined ||
      this.initiateModel.itemEstimatedValue < 0.0) {
        this.errorMsg = 'Invalid Unit Cost';
        return false;
    }

    return true;
  }

  initiate(): void {

    if (!this.validate()) {

      return;
    }

    this.notifyService.show('Initating', {classname: 'alert-info'});

    if (this.initiated) {
      this.initiated.emit(this.initiateModel);
    }
  }
}
