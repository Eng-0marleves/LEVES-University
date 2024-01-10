import { Component } from '@angular/core';
import { PageComponent } from './page/page.component';

@Component({
  selector: 'app-generate-quizz',
  standalone: true,
  imports: [PageComponent],
  templateUrl: './generate-quizz.component.html',
  styleUrl: './generate-quizz.component.scss'
})
export class GenerateQuizzComponent {
  isActive() {

  }
}
