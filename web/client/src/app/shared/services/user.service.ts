import { Injectable, Inject, PLATFORM_ID, InjectionToken } from '@angular/core';
import { DOCUMENT, isPlatformBrowser } from '@angular/common';
import { Observable, of, from, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { UserAccount } from '../models/user-account';
import { SystemService } from './system.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private storageKey = 'mrAppUserAccountCookie';
  private readonly documentIsAccessible: boolean;
  private user: UserAccount | null;

  initializedUrl = '';
  originUrl = '';
  loggedIn: Subject<UserAccount | null> = new Subject();
  data: any;

  constructor(
    private httpClient: HttpClient,
    @Inject(DOCUMENT) private document: any,
    @Inject(PLATFORM_ID) private platformId: InjectionToken<object>,
    private appSvc: SystemService) {

    this.documentIsAccessible = isPlatformBrowser(this.platformId);
    this.user = null;
  }

  get userAccount(): UserAccount | null {
    return this.user;
  }
  set userAccount(account: UserAccount | null) {
    this.user = account;
    this.loggedIn.next(this.userAccount);
  }

  hasClaim(claimValue: number): boolean {
    if(this.user && 
      this.user.permissionClaimValues && 
      this.user.permissionClaimValues.indexOf(claimValue.toString()) > -1) {
        return true;
      } else {
        return false;
      }
  }

  hasAnyClaim(claimValues: number[]): boolean {
    return claimValues.some(claim => {
      return this.hasClaim(claim);
    });
  }

  isLoggedIn(): boolean {
    if (!this.userAccount) {
      const accountCookie = this.getCookie(this.storageKey);
      const account = this.mapAccount(accountCookie);

      if (account) {
        this.userAccount = Object.assign(new UserAccount(), account);
      } else {
        // this.appSvc.log.debug('No account. \nKey= ' + accountCookie + '\nAccount= ' + account);
      }
    }

    return this.userAccount !== null;
  }

  getUserAccount(
    username: string,
    password: string ): Observable<UserAccount> {
      const data = {
        username,
        password
      };

      return this.httpClient.post<UserAccount>(this.originUrl + 'account/', data);
  }

  persistUserAccount(
    userAccount: UserAccount,
    persistCrossSession: boolean): void {
      const userAccountSerialized = JSON.stringify(userAccount);
      this.userAccount = userAccount;

      this.deleteCookie(this.storageKey);

      if (persistCrossSession === true) {
        this.setCookie(
          this.storageKey,
          userAccountSerialized,
          60);
    } else {
      this.setCookie(
        this.storageKey,
        userAccountSerialized,
        1);
    }
  }

  logout(): void {
    this.deleteCookie(this.storageKey);
    this.userAccount = null;
  }

  private mapAccount(cookie: string): UserAccount | null {
    const cookieParts = cookie.split(',expires');
    if (cookieParts && cookieParts[0] !== '' ) {
      const cookieToken = cookieParts[0];

      // this.appSvc.log.debug('Cookie token - ' + cookieToken + ' - end token.');
      const parsedJson = JSON.parse(cookieToken);
      const account = Object.assign(new UserAccount(), parsedJson);

      // this.appSvc.log.debug('Account exists ', account);
      return account;

    } else {
      // this.appSvc.log.debug('Account  map parts ', cookieParts);
    }

    return null;
  }

  private getCookie(name: string): string {
    if (this.documentIsAccessible && this.checkCookie(name)) {

      const regExp = this.getCookieRegExp(name);
      const result = regExp.exec(this.document.cookie);
      // this.appSvc.log.debug('Cookie ' + result[1]);

      return this.safeDecodeURIComponent(result && result.length > 0 ? result[1] : '');
    } else {
      // this.appSvc.log.debug('No cookie ');
      return '';
    }
  }

  private setCookie(
    name: string,
    value: string,
    expires?: number | Date | null
  ): void {
    const path = '';
    const domain = this.originUrl;
    const secure = true;
    const sameSite = 'Strict'; // 'Lax' | 'None' |
    const delimiter = ',';

    if (!this.documentIsAccessible) {
      return;
    }

    let cookieString: string = name + '=' + encodeURIComponent(value) + (value ? delimiter : '');

    if (expires && value) {
      if (typeof expires === 'number') {
        const dateExpires: Date = new Date(new Date().getTime() + (expires * 1000 * 60 * 60 * 24));

        cookieString += 'expires=' + dateExpires.toUTCString() + delimiter;
      } else {
        cookieString += 'expires=' + expires.toUTCString() + delimiter;
      }
    }

    if (path && value) {
      cookieString += 'path=' + path + delimiter;
    }

    if (domain && value) {
      cookieString += 'domain=' + domain + delimiter;
    }

    if (secure && value) {
      cookieString += 'secure,';
    }

    if (value) {
      cookieString += 'sameSite=' + sameSite + delimiter;
    }

    // this.appSvc.log.debug('Persist cookie ' + cookieString);

    this.document.cookie = cookieString;
  }

  private deleteCookie(name: string): void {
    if (!this.documentIsAccessible) {
      return;
    }

    this.appSvc.log.debug('Deleting cookie ' + name);
    this.setCookie(name, '');
  }

  private checkCookie(name: string): boolean {
    if (!this.documentIsAccessible) {
      return false;
    }

    const regExp: RegExp = this.getCookieRegExp(name);
    const exists: boolean = regExp.test(this.document.cookie);

    return exists;
  }

  private getCookieRegExp(name: string): RegExp {
    const escapedName: string = name; // .replace(/([\[\]\{\}\(\)\|\=\;\+\?\,\.\*\^\$])/gi, '\\$1');

    return new RegExp('(?:^' + escapedName + '|;\\s*' + escapedName + ')=(.*?)(?:;|$)', 'g');
  }

  private safeDecodeURIComponent(encodedURIComponent: string): string {
    try {
      return decodeURIComponent(encodedURIComponent);
    } catch {
      // probably it is not uri encoded. return as is
      return encodedURIComponent;
    }
  }
}
