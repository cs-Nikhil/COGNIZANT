import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-courses-page',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, RouterOutlet],
  templateUrl: './courses-page.component.html',
  styleUrl: './courses-page.component.scss'
})
export class CoursesPageComponent {}

