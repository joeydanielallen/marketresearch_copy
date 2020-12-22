import { Inject, Injectable } from '@angular/core';
import { LoggerService } from './logger.service';
import { NotifyService } from './notify.service';
import { WINDOW } from '../window-provider';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SystemService {

  constructor(
    // @Inject(WINDOW) private window: Window
    public notifier: NotifyService,
    public log: LoggerService) { }
}
