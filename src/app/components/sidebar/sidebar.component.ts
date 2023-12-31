import { NgOptimizedImage, CommonModule } from '@angular/common'
import { Component, OnInit } from '@angular/core';
import { ImageModule } from 'primeng/image';
import { ActivatedRoute, Router, RouterLink, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, NgOptimizedImage, ImageModule, RouterLink],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent implements OnInit {
  currentRoute: string | undefined;

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit() {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.currentRoute = this.route.snapshot.firstChild?.routeConfig?.path;
      }
    });
  }

  isCurrentRoute(route: string): boolean {
    return this.currentRoute === route;
  }

  toggleDropdown(): void {
    document.getElementById("dropdownList")?.classList.toggle("show")
  }
}
