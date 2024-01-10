import { Component, ViewChildren, QueryList, ElementRef, AfterViewInit, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionsService } from '../../../../services/questions.service';
import { QuestionComponent } from '../question/question.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule, QuestionComponent, FormsModule],
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements AfterViewInit {
  constructor(private questionsService: QuestionsService) {}

  questions: QuestionObject[] = [
    { questionComponent: new QuestionComponent() },
    { questionComponent: new QuestionComponent() }
  ];
  isRandomized: boolean = false;
  isWeighted: boolean = false;
  inputType: string = "radio";
  @ViewChildren(QuestionComponent) questionComponents: QueryList<QuestionComponent> | undefined;
  @Input() pageID: string | undefined;

  ngAfterViewInit() {
    if (this.questionComponents) {
      this.questions = this.questionComponents.toArray().map((component) => {
        return { questionComponent: component };
      });
    }
  }

  closeModal() {
    const modelDiv = document.getElementById("QuestionModal");
    if (modelDiv != null) {
      modelDiv.style.display = "none";
    }
  }

  save() {
    this.questionsService.addQuestionToPage()
  }

  AddOption() {
    const newQuestion: QuestionObject = { questionComponent: new QuestionComponent() };
    this.questions.push(newQuestion);
  }

  deleteQuestion(index: number) {
    if (index >= 0 && index < this.questions.length) {
      const questionToRemove = this.questions[index];
      this.questions.splice(index, 1);
    }
  }
}

interface QuestionObject {
  questionComponent: QuestionComponent;
}
