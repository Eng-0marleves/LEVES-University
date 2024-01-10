import { Component, Output, EventEmitter, Input } from '@angular/core';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-question',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent {
  @Output() deleteClicked: EventEmitter<void> = new EventEmitter<void>();
  @Input() isWeightedChecked: boolean = false;
  @Input() inputType: string = "radio";

  getQuestion(): string {
    return "Sample Question Text";
  }

  delete() {
    this.deleteClicked.emit();
  }
}
