import { Injectable, signal } from '@angular/core';

export type NotificationType = 'success' | 'info' | 'warning' | 'error';

export interface NotificationMessage {
  id: string;
  type: NotificationType;
  title: string;
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private readonly messages = signal<NotificationMessage[]>([]);

  readonly notifications = this.messages.asReadonly();

  success(title: string, message: string): void {
    this.push('success', title, message);
  }

  info(title: string, message: string): void {
    this.push('info', title, message);
  }

  warning(title: string, message: string): void {
    this.push('warning', title, message);
  }

  error(title: string, message: string): void {
    this.push('error', title, message);
  }

  dismiss(id: string): void {
    this.messages.update((messages) => messages.filter((message) => message.id !== id));
  }

  clear(): void {
    this.messages.set([]);
  }

  private push(type: NotificationType, title: string, message: string): void {
    const id = globalThis.crypto?.randomUUID?.() ?? `${Date.now()}-${Math.random()}`;
    this.messages.update((messages) => [...messages, { id, type, title, message }]);
  }
}

