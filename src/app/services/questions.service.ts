import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {
  private questionsSubject = new BehaviorSubject<any[]>([]);
  questions$ = this.questionsSubject.asObservable();

  Questions: Question[] = [];

  constructor() {}

  getQuestions() {
    return this.questions$;
  }

  addQuestion(newQuestion: object) {
    this.questionsSubject.next([...this.questionsSubject.value, newQuestion]);
  }

  addQuestionToPage() {
    console.log(this.getQuestions());

  }
}
interface Question {
  pageID: string;
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