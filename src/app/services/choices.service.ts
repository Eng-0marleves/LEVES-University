import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChoicesService {
  private choicesSubject = new BehaviorSubject<any[]>([]);
  choices$ = this.choicesSubject.asObservable();

  constructor() {}

  getChoices() {
    return this.choices$;
  }

  addChoice(newChoice: any) {
    this.choicesSubject.next([...this.choicesSubject.value, newChoice]);
  }}
