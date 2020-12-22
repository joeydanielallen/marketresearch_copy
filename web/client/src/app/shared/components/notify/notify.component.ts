import { Component, HostBinding, TemplateRef } from '@angular/core';
import { NotifyService } from '../../services/notify.service';

@Component({
  selector: 'app-notify',
  templateUrl: './notify.component.html',
  styleUrls: ['./notify.component.css']
  // host: {'[class.ngb-toasts]': 'true'}
})
export class NotifyComponent {
  @HostBinding('class.ngb-toasts') ngbToasts = 'true';

  constructor(public notifyService: NotifyService) { }

  isTemplate(toast): boolean { return toast.textOrTpl instanceof TemplateRef; }

  removeToast(toast): void {
    toast.options.classname = 'toast-fade';
    setTimeout(() => this.notifyService.remove(toast), 500);
  }
}
