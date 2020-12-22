import { Injectable } from '@angular/core';
import { TemplateInstance } from 'src/app/research/models/template-instance';

@Injectable({
  providedIn: 'root'
})
export class TemplateInstanceService {

  templateInstance: TemplateInstance;

  constructor() { }
}
