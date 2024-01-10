import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {

  private coursesSubject = new BehaviorSubject<any[]>([]);
  courses$ = this.coursesSubject.asObservable();

  constructor() {}

  getCourses() {
    return this.courses$;
  }

  addCourse(newCourse: any) {
    this.coursesSubject.next([...this.coursesSubject.value, newCourse]);
  }
}
