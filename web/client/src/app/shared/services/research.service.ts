import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { InitiateResearch } from '../../research/models/initiate-research';
import { InitiateResponse } from '../../research/models/initiate-response';
import { StartResearchRequest } from '../../research/models/start-research-request';
import { TemplateInstance } from 'src/app/research/models/template-instance';
import { TemplateInstanceSummary } from 'src/app/research/models/my-research';
import { TemplateInstanceAnswer } from 'src/app/research/models/template-instance-answer';
import { ResearchFormVendor } from 'src/app/research/models/research-form-vendor';

import { UserService } from 'src/app/shared/services/user.service';
import { of, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { throwError } from 'rxjs';

import { mockData } from '../../research/services/mockData';


@Injectable({
  providedIn: 'root'
})
export class ResearchService {

  constructor(
    private httpClient: HttpClient,
    private userService: UserService
  ) { }


  getTemplateInstanceSummaries(inProgressOnly = false): Observable<TemplateInstanceSummary[]> {
    let queryParam = '';

    if (inProgressOnly) {
      queryParam = '?onlyInProgress=true';
    }
    return this.httpClient.get<TemplateInstanceSummary[]>(this.userService.originUrl + 'ResearchDashboard/' + queryParam);
    // return of(mockData.hardcodedTemplateInstanceSummaries);
  }



  getInitiateResults(initiateQuery: InitiateResearch): Observable<InitiateResponse>{
    return this.httpClient.post<InitiateResponse>(this.userService.originUrl + 'InitiateResearch/', initiateQuery);
    // return of(mockData.hardcodedInitiateResponse);
  }



  createTemplateInstance(srRequest: StartResearchRequest): Observable<number>{
    return this.httpClient.post<number>(this.userService.originUrl + 'StartResearch/', srRequest);
    // return of(mockData.hardcodedTemplateId);
  }



  getTemplateInstance(templateId: number): Observable<TemplateInstance>{
    return this.httpClient.get<TemplateInstance>(this.userService.originUrl + `Research/${templateId}`);
    // return of(mockData.hardcodedTemplateInstance);
  }


  saveTemplateInstance(answers: TemplateInstanceAnswer[]): Observable<any> {
    console.log('in api call');
    console.log(answers);
    return this.httpClient.post<any>(this.userService.originUrl + 'ResearchAnswer/', answers, { observe: 'response' })
    .pipe(
      catchError((err: HttpErrorResponse) => {
        console.log('save failed: ');
        return throwError(err);
      }),
      map((res) => {
        console.log(res.status);
      })
    );

    // return of(true);
  }

  // CURRENTLY MOCK DATA
  completeResearch(id: number) {
    return this.httpClient.put<any>(this.userService.originUrl + `Research/${id}`, {});
  }

  getVendorList(searchText: string): Observable<any[]> {
    return this.httpClient.get<any>(this.userService.originUrl + `VendorSearch/${searchText}`);
    // return of(mockData.hardcodedVendorAnswers)
  }

  updateTemplateInstanceTitle(newTitle: string, id: number){
    return this.httpClient.put<any>(this.userService.originUrl + `ResearchName/?templateInstanceId=${id}&name=${newTitle}`, {});
  }

  getUserList(searchText: string) {
    return this.httpClient.get<any>
    (this.userService.originUrl + `UserSearch/?nameSearchValue=${searchText}&pageNumber=${1}&pageSize=${100}`);
  }

  addUserToForm(userAccountId: number, id: number) {
    return this.httpClient.post<any>
    (this.userService.originUrl + `ResearchUser/?templateInstanceId=${id}&userAccountId=${userAccountId}`, {});
  }

  removeUserFromForm(userAccountId: number) {
    return this.httpClient.delete<any>(this.userService.originUrl + `ResearchUser/${userAccountId}`);
  }

  getUsersOnForm(id: number) {
    return this.httpClient.get<any>(this.userService.originUrl + `ResearchUser/${id}`);
  }

  getVendorsAddedOnForm(templateInstanceId: number): Observable<ResearchFormVendor[]> {
    return this.httpClient.get<any>(this.userService.originUrl + `ResearchVendors/${templateInstanceId}`);
  }
}
