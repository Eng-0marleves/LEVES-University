  import { Component, Renderer2, ElementRef } from '@angular/core';
  import {CdkDragDrop, CdkDropList, CdkDrag, moveItemInArray} from '@angular/cdk/drag-drop';
  import { PageItemComponent } from './page-item/page-item.component';
  import { CommonModule } from '@angular/common';
  import { QuestionComponent } from '../question/question.component';
  import { QuizService } from '../../../../services/quizzes.service';
  import { PagesService } from '../../../../services/pages.service';
  import * as uuid from 'uuid';
  import { QuestionsService } from '../../../../services/questions.service';
  import { ModalComponent } from '../modal/modal.component';


@Component({
  selector: 'app-page',
  standalone: true,
  imports: [CdkDropList, CdkDrag, PageItemComponent, CommonModule, QuestionComponent, ModalComponent],
  templateUrl: './page.component.html',
  styleUrl: './page.component.scss'
})
export class PageComponent {
  pagesService = new PagesService();
  pages = this.pagesService.getPages();

  isDrag: boolean = false;
  count: number = this.pages.length;
  pageCount: string = "";

  constructor(private questionsService: QuestionsService, private renderer: Renderer2, private el: ElementRef) {}

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.pages, event.previousIndex, event.currentIndex);
    this.count = this.pages.length;
    console.log(this.pages);
  }


  addPage() {
    const newPage = `page ${this.count + 1}`;
    const pageId = uuid.v4();
    this.pages.push({
      pageId: pageId,
      pageTitle: newPage
    });
    this.pageCount = newPage;
    this.count++;
  }


  deletePage(page: any) {
    const index = this.pages.indexOf(page);
    if (index !== -1) {
      this.pages.splice(index, 1);
      this.count = this.pages.length;
    }
  }

  editTitle(title: string) {
    const newTitle = prompt('Enter the new title:', title);
    if (newTitle !== null && newTitle.trim() !== '') {
      const page = this.pages.find(p => p.pageTitle === title);
      if (page) {
        page.pageTitle = newTitle;
      }
    }
  }

  addQuestionToPage() {
    console.log(this.questionsService.getQuestions());
  }


}
