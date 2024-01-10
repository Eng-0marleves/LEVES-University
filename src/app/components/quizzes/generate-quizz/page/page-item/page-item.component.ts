import { Component, Input, Output, EventEmitter } from '@angular/core';
import {CdkDragDrop, CdkDropList, CdkDrag, moveItemInArray} from '@angular/cdk/drag-drop';
import { QuestionComponent } from '../../question/question.component';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { QuestionsService } from '../../../../../services/questions.service';
import { ModalComponent } from '../../modal/modal.component';

@Component({
  selector: 'app-page-item',
  standalone: true,
  imports: [CdkDropList, CdkDrag, QuestionComponent, CommonModule, NgbModule, ModalComponent],
  templateUrl: './page-item.component.html',
  styleUrl: './page-item.component.scss',
})

export class PageItemComponent {
  @Input() title: string = '';
  @Input() pageId: string = '';
  @Output() deleteClicked: EventEmitter<string> = new EventEmitter<string>();
  @Output() editTitleClicked: EventEmitter<string> = new EventEmitter<string>();
  @Output() addQuestionClicked: EventEmitter<string> = new EventEmitter<string>();

  constructor(private questionsService: QuestionsService) {}

  onDeleteClicked() {
    this.deleteClicked.emit(this.pageId);
  }

  onEditTitleClicked() {
    this.editTitleClicked.emit(this.title);
  }

  onAddQuestionClicked() {
    this.addQuestionClicked.emit(this.pageId);
  }

  openModal() {
    const modelDiv = document.getElementById("QuestionModal");
    const modelDivDialog = document.querySelector("#QuestionModal .modal-dialog");
    if (modelDiv != null) {
      modelDiv.style.display = "block";
      modelDiv.style.background = "rgba(0, 0, 0, .2)";
    }
  }
}
