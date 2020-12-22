import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'zip'
})
export class ZipPipe implements PipeTransform {

  transform(zip: string): string {
    if (zip.length === 9) {

      if (zip.substring(5) === '0000') { return zip.substring(0, 5); }

      return zip.substring(0, 5) + '-' + zip.substring(5);

    } else if (zip.length > 5) {

      return zip.substring(0, 5) + '-' + zip.substring(5);

    }

    return zip;
  }

}
