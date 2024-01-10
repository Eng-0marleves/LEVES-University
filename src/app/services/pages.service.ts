import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import * as uuid from 'uuid';

@Injectable({
  providedIn: 'root'
})
export class PagesService {
  pages: Page[] = [
    {
      pageId: uuid.v4(),
      pageTitle: "page 1"
    }
  ];

  addPage(page: Page) {
    this.pages.push(page);
  }

  getPages() {
    return this.pages;
  }
}

interface Page {
  pageId: string,
  pageTitle: string;
}
