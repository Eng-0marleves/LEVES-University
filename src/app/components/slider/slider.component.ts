import { Component, ElementRef, OnDestroy, OnInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-slider',
  standalone: true,
  imports: [],
  templateUrl: './slider.component.html',
  styleUrl: './slider.component.scss'
})

export class SliderComponent implements OnInit, OnDestroy {
  private autoScrollInterval: any;
  private autoScrollPaused: boolean = false;

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit() {
    this.startAutoScroll();
  }

  ngOnDestroy() {
    this.stopAutoScroll();
  }

  startAutoScroll() {
    this.autoScrollInterval = setInterval(() => {
      if (!this.autoScrollPaused) {
        this.scroll('next');
      }
    }, 5000);
  }

  stopAutoScroll() {
    clearInterval(this.autoScrollInterval);
  }

  pauseAutoScroll(duration: number) {
    this.autoScrollPaused = true;
    setTimeout(() => {
      this.autoScrollPaused = false;
    }, duration);
  }

  scroll(direction: 'next' | 'prev') {
    this.pauseAutoScroll(5000);

    const container = this.el.nativeElement.querySelector('.slides-container');
    const scrollWidth = container.offsetWidth;
    const slides = document.querySelectorAll('.slid');
    const slidesWidth = scrollWidth * slides.length;

    if (direction === 'next') {
      this.renderer.setProperty(container, 'scrollLeft', container.scrollLeft + scrollWidth);
      if (container.scrollLeft + scrollWidth >= slidesWidth - scrollWidth) {
        this.renderer.setProperty(container, 'scrollLeft', 0);
      }
    } else if (direction === 'prev') {
      this.renderer.setProperty(container, 'scrollLeft', container.scrollLeft - scrollWidth);
      if (container.scrollLeft <= 0) {
        this.renderer.setProperty(container, 'scrollLeft', slidesWidth - scrollWidth);
      }
    }
  }
}
