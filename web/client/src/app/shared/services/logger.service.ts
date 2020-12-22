import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {

  constructor() { }

  public readonly debugLogLevel = 'debug';
  public readonly infoLogLevel = 'info';

  public currentLogLevel = this.debugLogLevel;

  debug(message: string, objectToStringify?: object): void {
    if (this.currentLogLevel !== this.debugLogLevel)
    {
      return;
    }
    // let msg = message + ' ' + objectToStringify !== null ? JSON.stringify(objectToStringify) : '';

    console.log('Log Debug - ', message, objectToStringify === null ? '' : objectToStringify);
  }

  info(message: string, objectToStringify: object): void {
    if (this.currentLogLevel !== this.infoLogLevel) {
      return;
    }
    const msg = message + ' ' + objectToStringify !== null ? JSON.stringify(objectToStringify) : '';

    console.log('Log Info - ' + msg);
  }

  error(message: string, objectToStringify: object): void {
    const msg = message + ' ' + objectToStringify !== null ? JSON.stringify(objectToStringify) : '';

    console.log('Log Error - ' + msg);
  }
}
