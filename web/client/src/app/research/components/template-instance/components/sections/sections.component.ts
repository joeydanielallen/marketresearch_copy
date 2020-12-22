import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { TemplateSection } from '../../../../models/template-section';
import { TemplateInstanceService } from '../../template-instance.service';
import { ResearchService } from 'src/app/shared/services/research.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-sections',
  templateUrl: './sections.component.html',
  styleUrls: ['./sections.component.css']
})
export class SectionsComponent implements OnInit, OnDestroy {

  @Input() sections: TemplateSection[];
  @Input() readOnly: boolean;
  @Output() newChange = new EventEmitter();

  width50 = [1, 3, 4, 5, 8];

  constructor(
    private templateInstanceService: TemplateInstanceService,
    private researchService: ResearchService
  ) { }

  private subscriptions = new Subscription();

  groupings = [];
  repeatableGrouping = [];
  showVendorSearch = false;
  searchText = '';
  vendorsFound: boolean;
  vendorResults: any[];
  showVendorSelections = false;
  isVendorSearching = false;

  ngOnInit(): void {
    this.getGroupings();
    this.clearSearch();
    this.showVendorSearch = false;


  }

  ngOnDestroy(): void {
    this.groupings = [];
    this.subscriptions.unsubscribe();
  }

  isFormCompleted(): boolean {
    return this.templateInstanceService.templateInstance.completedOn !== null;
  }


  confirmSelection(vendorResult, sectionId): void {
    this.addGrouping(vendorResult, sectionId);
    this.showVendorSearch = false;
    this.clearSearch();
  }

  searchForVendors(): void {
    this.showVendorSelections = false;
    this.vendorsFound = null;
    this.vendorResults = [];

    if (this.searchText) {
      this.isVendorSearching = true;

      this.subscriptions.add(
        this.researchService.getVendorList(this.searchText).subscribe((res) => {
          this.vendorResults = res;
          if (this.vendorResults.length > 0) {
            this.vendorsFound = true;
          } else {
            this.vendorsFound = false;
          }
          this.isVendorSearching = false;
        }, (e) => {
          this.isVendorSearching = false;
          console.log('Error searching vendors ' + e);
        })
      );



    } else {
      this.vendorsFound = false;
    }
  }

  clearSearch(): void {
    this.vendorResults = [];
    this.searchText = '';
    this.vendorsFound = null;
    this.showVendorSelections = false;
    this.isVendorSearching = false;
  }

  displayVendorSearch(): void {
    this.clearSearch();
    this.showVendorSearch = true;
  }

  hideVendorSearch(): void {
    this.showVendorSearch = false;
    this.clearSearch();
  }

  selectVendor(vendorResult): void {
    this.vendorResults = [vendorResult];
    this.showVendorSelections = true;
  }

  getGroupings(): void {
    this.groupings = [];
    let newGrouping = [];



    const groupingAnswers = this.templateInstanceService.templateInstance.answers.filter((ans) => {
      return ans.answerGroupIndex !== null;
    });


    if (groupingAnswers.length > 0) {



      groupingAnswers.sort((a, b) => {
        return (a.answerGroupIndex > b.answerGroupIndex) ? 1 : -1;
      });

      console.log(groupingAnswers);

      let groupIndexCounter = groupingAnswers[0].answerGroupIndex;

      for (const groupingAnswer of groupingAnswers) {
        const currentAnswerGroupIndex = groupingAnswer.answerGroupIndex;

        if (currentAnswerGroupIndex !== 0){

          if (currentAnswerGroupIndex !== groupIndexCounter){
            groupIndexCounter = currentAnswerGroupIndex;
            this.groupings.push(newGrouping);
            newGrouping = [];
          }

          newGrouping.push(groupingAnswer);
        }

      }

      if (newGrouping.length !== 0){
        this.groupings.push(newGrouping);
      }

    }

    console.log(this.groupings);
    console.log(this.templateInstanceService.templateInstance.answers);


  }

  addGrouping(vendorResult, sectionId): void {

    let newGroupIndex;

    if (this.groupings.length === 0){
      newGroupIndex = 1;
    } else {
      newGroupIndex = this.groupings[this.groupings.length - 1][0].answerGroupIndex + 1;
    }

    this.getRepeatableQuestions();

    this.repeatableGrouping.forEach((question, index) => {

      this.clearOldAnswer(question);

      const newGroupingAnswer = {
        answerGroupIndex: newGroupIndex,
        answerValue: this.getAnsValue(vendorResult, index),
        id: 0,
        sectionQuestionId: question.id,
        templateInstanceId: this.templateInstanceService.templateInstance.id,
        templateSectionId: sectionId
      };

      this.templateInstanceService.templateInstance.answers.push(newGroupingAnswer);

    });

    this.getGroupings();
    this.newChange.emit();

  }

  getAnsValue(vendorResult, index): string {
    let ansValue = 'N/A';

    switch (index){
      case 0: {
        if (vendorResult.name){
          ansValue = vendorResult.name;
        }

        break;
      }
      case 1: {
        if (vendorResult.dunsId){
          ansValue = vendorResult.dunsId;
        } else if (vendorResult.cageCode) {
          ansValue = vendorResult.cageCode;
        }

        break;
      }
      case 2: {
        if (vendorResult.setAside){
          if (vendorResult.setAside.description){
            ansValue = vendorResult.setAside.description;
          }
        }

        break;
      }
      case 3: {
        let location = '';

        if (vendorResult.addressLine1){
          location += vendorResult.addressLine1;

          if (vendorResult.addressLine2){
            location += ', ' + vendorResult.addressLine2;
          }

        }

        if (vendorResult.city && vendorResult.stateAbbreviation){
          location += ', ' + vendorResult.city + ', ' + vendorResult.stateAbbreviation;

          if (vendorResult.postalCode){
            location += ', ' + vendorResult.postalCode;
          }

        }

        ansValue = location;
        break;
      }
      case 4: {
        // ansValue = "None";
        break;
      }
      case 5: {
        // ansValue = "None";
        break;
      }
      case 6: {
        if (vendorResult.capability){
          ansValue = vendorResult.capability;
        }

        break;
      }
      case 7: {
        if (vendorResult.pastPerformance){
          ansValue = vendorResult.pastPerformance;
        }

        break;
      }
      case 8: {
        ansValue = vendorResult.id.toString();
        break;
        }
    }

    return ansValue;

  }


  removeGrouping(grouping, section): void {
    this.templateInstanceService.templateInstance.answers = this.templateInstanceService.templateInstance.answers.filter((ans) => {
      let keep;

      if (ans.answerGroupIndex !== grouping[0].answerGroupIndex){
        keep = true;
      } else if (ans.templateSectionId !== section.id) {
        keep = true;
      } else {
        keep = false;
        console.log('found answer to remove');
      }

      return keep;
    });

    this.getGroupings();
    this.newChange.emit();

  }



  getRepeatableQuestions(): void {
    this.repeatableGrouping =  this.templateInstanceService.templateInstance.template.sections[6].questions.filter((question) => {
      return question.groupIndex === 0;
    });
  }



  clearOldAnswer(question): void {

    const answerIndex = this.templateInstanceService.templateInstance.answers.findIndex((ans) => {
      return question.id === ans.sectionQuestionId && ans.answerGroupIndex === null;
    });

    if (answerIndex !== -1) {
      this.templateInstanceService.templateInstance.answers.splice(answerIndex, 1);
      console.log('removed answer');
    }

  }


}
