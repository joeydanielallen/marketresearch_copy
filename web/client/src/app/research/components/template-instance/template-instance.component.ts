import { Component, OnDestroy, OnInit } from '@angular/core';
import { ResearchService } from '../../../shared/services/research.service';
import { TemplateInstance } from 'src/app/research/models/template-instance';
import { TemplateSection } from '../../models/template-section';
import { ActivatedRoute, Router } from '@angular/router';
import { NotifyService } from 'src/app/shared/services/notify.service';
import { UserService } from 'src/app/shared/services/user.service';
import { TemplateInstanceService } from './template-instance.service';
import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-template-instance',
  templateUrl: './template-instance.component.html',
  styleUrls: ['./template-instance.component.css']
})
export class TemplateInstanceComponent implements OnInit, OnDestroy {

  constructor(
    private researchService: ResearchService,
    private route: ActivatedRoute,
    private router: Router,
    private notifyService: NotifyService,
    private userService: UserService,
    private templateInstanceService: TemplateInstanceService
  ) { }

  private subscriptions = new Subscription();

  templateId: number;
  templateInstance;
  questionCounter = 1;
  submittingResearch = false;
  unSavedChanges = false;
  autoSaveIntervalId;
  autoSaveTime: Date;
  readOnly = true;
  exporting = false;
  reOpening = false;
  userIsCreator = false;

  showUsers = false;
  showUserSearch = false;
  searchText = '';
  usersFound;
  userResults = [];

  localUsersFromServer = [];
  isLoading = true;



  ngOnInit(): void {

    window.scrollTo(0, 0);
    this.startAutoSave();
    this.templateId = this.route.snapshot.params.id;

    // get the localUser data from server so that we have access to templateInstanceUser.id
    this.subscriptions.add(
      this.researchService.getUsersOnForm(this.templateId).subscribe((res) => {
        this.localUsersFromServer = res;
      })
    );

    this.get_template_instance(this.templateId);

  }

  ngOnDestroy() {
    clearInterval(this.autoSaveIntervalId);
    this.templateInstanceService.templateInstance = null;
    this.subscriptions.unsubscribe();
  }

  toggleShowUsers() {
    this.showUsers = !this.showUsers;
    this.clearUserSearch();
    this.showUserSearch = false;
  }

  displayUserSearch() {
    this.clearUserSearch();
    this.showUserSearch = true;
  }

  clearUserSearch() {
    this.usersFound = null;
    this.searchText = '';
    this.userResults = [];
  }

  searchForUsers() {

    this.subscriptions.add(
      this.researchService.getUserList(this.searchText).subscribe((res) => {

        this.userResults = res;

        if (this.userResults.length > 0){
          this.usersFound = true;
        } else {
          this.usersFound = false;
        }

      })
    );


  }

  addUser(user) {

    // if the user is not the creator, add them to the form, otherwise don't
    if (user.userAccountId !== this.templateInstanceService.templateInstance.createdByAppUser.id) {

      // api call with template instance id and user account id
      this.researchService.addUserToForm(user.userAccountId, this.templateInstanceService.templateInstance.id).subscribe((res) => {

        // creating new object so that .id calls don't crash due to .userAccountId
        const newUser = {
          firstName: user.firstName,
          lastName: user.lastName,
          id: user.userAccountId
        };

        // updates the local app users array
        this.templateInstanceService.templateInstance.appUsers.push(newUser);

        // update the localUsers .id
        this.subscriptions.add(
          this.researchService.getUsersOnForm(this.templateId).subscribe((userRes) => {
            this.localUsersFromServer = userRes;
          })
        );


      });


    } else {
      console.log('Can\'t add creator of form to Other Users.');
    }

    this.showUserSearch = false;
    this.clearUserSearch();


  }

  removeUser(localUser) {

      // find the index of templateInstanceUser with the same account id as the local users
      const templateInstanceUserIndex = this.localUsersFromServer.findIndex((templateInstanceUser) => {
        return templateInstanceUser.userAccountId === localUser.id;
      });

      // the .id of this user is the templateInstanceUser id, not the userAccountId
      const userToRemove = this.localUsersFromServer[templateInstanceUserIndex];

      // remove the user from the templateInstanceRepo
      this.researchService.removeUserFromForm(userToRemove.id).subscribe((res) => {

        // update appUsers array
        this.templateInstanceService.templateInstance.appUsers = this.templateInstanceService.templateInstance.appUsers.filter((user) => {

          // these two user variable are both localUsers so we can compare the same .id
          return localUser.id !== user.id;
        });
      });
  }


  updateTitle(e) {
    const newTitle = e.target.value;

    this.researchService.updateTemplateInstanceTitle(newTitle, this.templateInstanceService.templateInstance.id).subscribe((res) => {
      this.templateInstanceService.templateInstance.name = newTitle;
    });

  }

  getTemplateInstance(){
    return this.templateInstanceService.templateInstance;
  }

  get_template_instance(id) {
    this.subscriptions.add(
      this.researchService.getTemplateInstance(id).subscribe(res => {

        this.templateInstanceService.templateInstance = res;

        this.checkTemplateInstancePermissions();
        this.isLoading = false;
        console.log(this.templateInstanceService.templateInstance);

      }, (e) => {
        this.isLoading = false;
        this.notifyService.show('An error occurred. Please try again.', {classname: 'alert-danger'});
      })
    );
  }


  research_submit() {

    this.submittingResearch = true;

    // clear out in progress search
    this.clearUserSearch();
    this.showUserSearch = false;


    let submitResearchSuccess;

    this.notifyService.show('Submitting Research', {classname: 'alert-info'});

    this.researchService.completeResearch(this.templateInstanceService.templateInstance.id).subscribe((res) => {
      submitResearchSuccess = true;

      console.log(this.templateInstanceService.templateInstance.completedOn);

      if (submitResearchSuccess) {
        this.notifyService.show('Research Submitted', {classname: 'alert-success'});

        this.router.navigate(['./summary'], {relativeTo: this.route});

        this.submittingResearch = false;
      } else {
        this.notifyService.show('Error with Submit', {classname: 'alert-danger'});
      }

    });


  }



  reOpen() {

    this.reOpening = true;

    let reOpenSuccess;

    this.notifyService.show('Re-Opening Research', {classname: 'alert-info'});

    this.researchService.completeResearch(this.templateInstanceService.templateInstance.id).subscribe((res) => {
      reOpenSuccess = true;

      console.log(this.templateInstanceService.templateInstance.completedOn);

      this.notifyService.show('Re-Opening Research', {classname: 'alert-info'});

      if (reOpenSuccess) {
        this.notifyService.show('Research Re-Opened', {classname: 'alert-success'});

        this.get_template_instance(this.templateId);
        console.log(this.templateInstanceService.templateInstance.completedOn);


        this.reOpening = false;
      } else {
        this.notifyService.show('Error with Re-Open', {classname: 'alert-danger'});
      }
    });


  }






  save_progress() {
    console.log(this.templateInstanceService.templateInstance.answers);
    return this.researchService.saveTemplateInstance(this.templateInstanceService.templateInstance.answers);
  }

  manualSave() {
    if (this.unSavedChanges) {
      this.notifyService.show('Saving Progress', {classname: 'alert-info'});

      // remove this later
      this.unSavedChanges = false;

      this.save_progress().subscribe((res) => {
        const saveSuccess = true;
        console.log(saveSuccess);

        if (saveSuccess) {
          this.notifyService.show('Progress Saved', {classname: 'alert-success'});
          this.unSavedChanges = false;
        } else {
          this.notifyService.show('Error with Save', {classname: 'alert-danger'});
        }

      });



    }
  }

  startAutoSave() {
    this.autoSaveIntervalId = setInterval(() => {

      if (this.unSavedChanges) {
        console.log('auto saved');

        // remove this later
        this.unSavedChanges = false;

        this.save_progress().subscribe((res) => {
          const saveSuccess = true;
          console.log(saveSuccess);

          if (saveSuccess) {
            this.updateAutoSaveTime();
            this.unSavedChanges = false;
          } else {
            // do nothing or something?
          }

        });


      } else {
        console.log('NOT auto saved');
      }

    }, 5000);
  }



  updateAutoSaveTime() {
    this.autoSaveTime = new Date();
  }




  changesMade() {
    this.unSavedChanges = true;
  }



  checkTemplateInstancePermissions() {

    const user = this.userService.userAccount;
    const creator = this.templateInstanceService.templateInstance.createdByAppUser.id;

    if (user.userAccountId === creator) {
      this.userIsCreator = true;
    }

    // checks the acces right array for the form and grabs the index of the local user that matches
    //   the logged in user, if it doesn't exist then the user doesn't have access and -1 is returned
    const userIndex = this.templateInstanceService.templateInstance.appUsers.findIndex((localUser) => {
      return localUser.id === user.userAccountId;
    });

    if (user.userAccountId === creator || userIndex !== -1) {
      this.readOnly = false;
    } else {
      this.readOnly = true;
    }


  }



}
