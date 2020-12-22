import { Pipe, PipeTransform } from '@angular/core';
import { TemplateInstanceSummary } from 'src/app/research/models/my-research';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(templates: TemplateInstanceSummary[], searchText: string): any[] {
    if (!templates) {
      return [];
    }
    if (!searchText) {
      return templates;
    }
    searchText = searchText.toLocaleLowerCase();

    return templates.filter(template => {
      return template.title.toLocaleLowerCase().includes(searchText);
    });
  }

}
