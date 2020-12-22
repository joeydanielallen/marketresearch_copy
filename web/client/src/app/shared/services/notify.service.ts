import { Injectable, TemplateRef } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class NotifyService {
  toasts: any[] = [];

  showInfo(textOrTpl: string | TemplateRef<any>): void {
    this.show(textOrTpl, {classname: 'alert-info'});
  }

  showDanger(textOrTpl: string | TemplateRef<any>): void {
    this.show(textOrTpl, {classname: 'alert-danger'});
  }

  showSuccess(textOrTpl: string | TemplateRef<any>): void {
    this.show(textOrTpl, {classname: 'alert-success'});
  }

  // TODO Depricate
  show(textOrTpl: string | TemplateRef<any>, options: any = {}): void {
    this.toasts.push({ textOrTpl, options });
  }

  remove(toast: string | TemplateRef<any>): void {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}
