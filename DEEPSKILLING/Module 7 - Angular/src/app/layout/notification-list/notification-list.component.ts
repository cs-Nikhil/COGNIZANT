import { NgClass } from '@angular/common';
import { Component, inject } from '@angular/core';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-notification-list',
  standalone: true,
  imports: [NgClass],
  templateUrl: './notification-list.component.html',
  styleUrl: './notification-list.component.scss'
})
export class NotificationListComponent {
  protected readonly notificationService = inject(NotificationService);

  dismiss(id: string): void {
    this.notificationService.dismiss(id);
  }
}
