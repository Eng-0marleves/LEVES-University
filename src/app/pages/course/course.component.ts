import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router, RouterLink, RouterOutlet } from '@angular/router';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-course',
  standalone: true,
  imports: [RouterLink, RouterOutlet, NgClass],
  templateUrl: './course.component.html',
  styleUrl: './course.component.scss'
})
export class CourseComponent implements OnInit {
  activeLink: string = '';

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit() {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.activeLink = this.route.firstChild?.snapshot.routeConfig?.path || '';
      }
    });
  }

  isLinkActive(link: string): boolean {
    return this.activeLink === link;
  }
}
