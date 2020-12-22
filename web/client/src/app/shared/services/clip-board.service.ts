import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ClipBoardService {
   copyToClipboard(toCopy: string): void {

    const createCopy = (e: ClipboardEvent) => {
      e.clipboardData.setData('text/plain', toCopy);
      e.preventDefault();
    };

    document.addEventListener('copy', createCopy );
    document.execCommand('copy');
    document.removeEventListener('copy', createCopy );
  }
}
