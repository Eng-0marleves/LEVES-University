import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-quizzes',
  standalone: true,
  imports: [RouterLink, RouterOutlet],
  templateUrl: './quizzes.component.html',
  styleUrl: './quizzes.component.scss'
})
export class QuizzesComponent {

}
