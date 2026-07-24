import { Injectable, computed, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthUser, LoginCredentials } from '../models/auth.model';
import { NotificationService } from './notification.service';

const AUTH_STORAGE_KEY = 'student-course-portal.auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly currentUser = signal<AuthUser | null>(this.readStoredUser());

  readonly user = this.currentUser.asReadonly();
  readonly isAuthenticated = computed(() => this.currentUser() !== null);

  constructor(
    private readonly notifications: NotificationService,
    private readonly router: Router
  ) {}

  login(credentials: LoginCredentials): boolean {
    if (!credentials.email.trim() || !credentials.password.trim()) {
      this.notifications.error('Login failed', 'Email and password are required.');
      return false;
    }

    const user: AuthUser = {
      name: 'Admin User',
      email: credentials.email,
      role: credentials.email.toLowerCase().includes('admin') ? 'admin' : 'student',
      token: `token-${btoa(credentials.email)}`
    };

    this.currentUser.set(user);
    localStorage.setItem(AUTH_STORAGE_KEY, JSON.stringify(user));
    this.notifications.success('Welcome back', 'You are now signed in.');
    return true;
  }

  logout(): void {
    this.currentUser.set(null);
    this.safeStorage()?.removeItem(AUTH_STORAGE_KEY);
    this.notifications.info('Signed out', 'Your session has been cleared.');
    void this.router.navigate(['/home']);
  }

  getToken(): string | null {
    return this.currentUser()?.token ?? null;
  }

  isLoggedIn(): boolean {
    return this.currentUser() !== null;
  }

  private readStoredUser(): AuthUser | null {
    const storage = this.safeStorage();
    if (!storage) {
      return null;
    }

    const raw = storage.getItem(AUTH_STORAGE_KEY);
    if (!raw) {
      return null;
    }

    try {
      return JSON.parse(raw) as AuthUser;
    } catch {
      return null;
    }
  }

  private safeStorage(): Storage | null {
    try {
      return globalThis.localStorage;
    } catch {
      return null;
    }
  }
}
