import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit {
  menuBtn: any | null;

  ngOnInit(): void {
    this.menuBtn = document.getElementById("menuBtn");
  }

  toggleMenuBtn(): void {
    this.menuBtn?.classList.toggle("fa-xmark")
  }
}
