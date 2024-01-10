import { Component } from '@angular/core';
import { SliderComponent } from '../../components/slider/slider.component';
import { PostComponent } from '../../components/post/post.component';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [SliderComponent, PostComponent],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent {

}
