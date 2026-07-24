import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './layout/header/header.component';
import { LoadingIndicatorComponent } from './layout/loading-indicator/loading-indicator.component';
import { NotificationListComponent } from './layout/notification-list/notification-list.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, LoadingIndicatorComponent, NotificationListComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
}
