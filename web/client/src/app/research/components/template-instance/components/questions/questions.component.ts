import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TemplateQuestion } from '../../../../models/template-questions';
import { TemplateInstanceService } from '../../template-instance.service';
import { ResearchService } from 'src/app/shared/services/research.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit, OnDestroy {

  @Input() question: TemplateQuestion;
  @Input() readOnly: boolean;
  @Input() templateSectionId: number;
  @Input() answerGroupIndex;

  private subscriptions = new Subscription();

  value;
  vendorAnswers;
  answerIndex;
  addingVendor = false;
  vendorResults;
  searchText;
  vendorsFound = true;
  formCompleted = false;
  selections = [];

  constructor(
    private templateInstanceService: TemplateInstanceService,
    private reserachService: ResearchService
  ) { }



  ngOnInit(): void {

    if (this.templateInstanceService.templateInstance.completedOn === null) {
      this.formCompleted = false;
    } else {
      this.formCompleted = true;
    }

    if (this.question.answerType !== 6 && this.question.answerType !== 5 && this.question.answerType !== 7){
      this.getAnswer();
    } else if (this.question.answerType === 5 || this.question.answerType === 7) {
      this.getSelections();
    }

  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }


  isCheckboxDisabled(id){
    let disabled = true;

    if (!(this.selections.length >= this.question.maxLength && this.question.maxLength !== 0 && !this.selections.includes(id.toString()))){
      disabled = false;
    }

    return disabled;
  }


  getSelections() {

    this.selections = [];

    const selectAnswers = this.templateInstanceService.templateInstance.answers.filter((templateAnswer) => {
      return templateAnswer.sectionQuestionId === this.question.id;
    });

    selectAnswers.forEach((ans) => {
      this.selections.push(ans.answerValue);
    });

  }


  checkboxClick(id) {

    if (this.selections.includes(id.toString())) {

      const answerIndex = this.templateInstanceService.templateInstance.answers.findIndex((ans) => {
        return ans.sectionQuestionId === this.question.id && ans.answerValue === id.toString();
      });

      this.templateInstanceService.templateInstance.answers.splice(answerIndex, 1);

    } else {

      if (this.selections.length <= this.question.maxLength || this.question.maxLength === 0) {
        this.addAnswer(id.toString());

      }

    }

    this.getSelections();

  }


  // for getting single answer for single questions (not vendor select or mult-select)
  getAnswer() {
    this.answerIndex = this.templateInstanceService.templateInstance.answers.findIndex(ans => {
      let keep = false;

      // we want the answer where the question is the same and the groupIndex is the same

      if (this.question.groupIndex === null){
        if (ans.sectionQuestionId === this.question.id) {
          keep = true;
        }
      } else {
        if (ans.sectionQuestionId === this.question.id){

          if (ans.answerGroupIndex === this.answerGroupIndex){
            keep = true;
          } else {

          }

        }
      }

      return keep;
    });

    if (this.answerIndex === -1) {
      // this.addAnswer();
      // this.getAnswer();
      // console.log(this.question)
    } else {
      this.value = this.templateInstanceService.templateInstance.answers[this.answerIndex].answerValue;
    }

  }



  onChange() {
    this.templateInstanceService.templateInstance.answers[this.answerIndex].answerValue = this.value;
  }





  getNewId() {

    const length = this.vendorAnswers.length;
    let newId = 1;

    if (length !== 0) {
      newId = this.vendorAnswers[length - 1].newVendorId + 1;
    }

    return  newId;

  }


  addAnswer(value?){

    let answerValue = '';

    if (value) {
      answerValue = value;
    }

    this.templateInstanceService.templateInstance.answers.push({
      id: 0,
      templateInstanceId: this.templateInstanceService.templateInstance.id,
      templateSectionId: this.templateSectionId,
      sectionQuestionId: this.question.id,
      answerGroupIndex: null,
      answerValue
    });
  }









  searchForVendors(){

    if (!this.searchText){
      console.log('nothing in search text');
    }

    this.subscriptions.add(
      this.reserachService.getVendorList(this.searchText).subscribe((res) => {
        this.vendorResults = res;
        console.log(res);

        if (this.vendorResults.length === 0) {
          this.vendorsFound = false;
        } else {
          this.vendorsFound = true;
        }

      })
    );



  }


  resetSearch(){
    this.vendorResults = [];
    this.searchText = '';
    this.vendorsFound = null;
  }

}
