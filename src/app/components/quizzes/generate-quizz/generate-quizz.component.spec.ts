import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateQuizzComponent } from './generate-quizz.component';

describe('GenerateQuizzComponent', () => {
  let component: GenerateQuizzComponent;
  let fixture: ComponentFixture<GenerateQuizzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GenerateQuizzComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GenerateQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
