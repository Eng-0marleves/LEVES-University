import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  private quizSubject = new BehaviorSubject<Quiz>({ pages: [] });
  quiz$ = this.quizSubject.asObservable();

  constructor() {}

  getQuiz() {
    return this.quiz$;
  }

  addQuestionToPage(pageID: string, question: string, options: Option[], isWeighted: boolean, isRandomized: boolean) {
    const currentQuiz = this.quizSubject.value;
    const updatedPages = [...currentQuiz.pages];

    let currentPage = updatedPages.find(page => page.pageID === pageID);
    if (!currentPage) {
      currentPage = { pageID, questions: [] };
      updatedPages.push(currentPage);
    }

    currentPage.questions.push({ question, options, isWeighted, isRandomized });

    this.quizSubject.next({ ...currentQuiz, pages: updatedPages });
  }
}

interface Quiz {
  pages: Page[];
}

interface Page {
  pageID: string;
  questions: Question[];
}

interface Question {
  question: string;
  options: Option[];
  isWeighted: boolean;
  isRandomized: boolean;
}

interface Option {
  option: string;
  isCorrect: boolean;
  isWeighted: boolean;
}
