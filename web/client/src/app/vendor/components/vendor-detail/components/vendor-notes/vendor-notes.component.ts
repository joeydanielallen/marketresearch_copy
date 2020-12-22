import { Component, OnInit, OnDestroy, Input, Output, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs';
import { NotifyService } from 'src/app/shared/services/notify.service';
import { UserService } from 'src/app/shared/services/user.service';
import { VendorService } from 'src/app/shared/services/vendor.service';
import { NewVendorNote } from 'src/app/vendor/models/new-vendor-note';

import { ResearchVendorNote } from '../../models/research-vendor/research-vendor-note';

@Component({
  selector: 'app-vendor-notes',
  templateUrl: './vendor-notes.component.html',
  styleUrls: ['./vendor-notes.component.css']
})
export class VendorNotesComponent implements OnInit, OnDestroy {

  @Output() refreshVendorData = new EventEmitter();
  @Input() mrVendorNotes;
  @Input() mrVendorId;
  @Input() mrDataLoading;

  constructor(
    private vendorService: VendorService,
    private notifyService: NotifyService,
    private userService: UserService
  ) { }

    private subscriptions = new Subscription();

    showNewNoteTextbox = false;
    newNoteTitle = '';
    newNoteText = '';




  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }



  clearNoteFields(): void {
    this.newNoteText = '';
    this.newNoteTitle = '';
    this.showNewNoteTextbox = false;
  }

  openNewNote(): void {
    this.showNewNoteTextbox = true;
  }

  addNote(): void {

    if (this.newNoteText.length > 0) {

      const newNote = new NewVendorNote();
      newNote.vendorId = this.mrVendorId;
      newNote.title = this.newNoteTitle;
      newNote.note = this.newNoteText;


      this.vendorService.addVendorNote(newNote).subscribe(res => {
        this.refreshVendorData.emit();

        console.log('note added?');
        console.log(newNote);

        this.clearNoteFields();

      });
      

    }
  }

  cancelAddNote(): void {
    this.clearNoteFields();
  }


  removeNote(note: ResearchVendorNote): void {
    console.log(note);


    const userIsOwner: boolean = this.checkPermissions(note.createdByAppUser.userAccountId);

    if (userIsOwner) {

      this.vendorService.removeVendorNote(note.id).subscribe(res => {
        this.refreshVendorData.emit();
        console.log('note removed?');
      });

    } else {
      this.notifyService.show('Must be note creator.', {classname: 'alert-danger'});
    }


  }


  checkPermissions(noteCreatorId: number): boolean {
    console.log(this.userService.userAccount);

    if (noteCreatorId === this.userService.userAccount.userAccountId) {
      return true;
    } else {
      return false;
    }

  }










}
