import { computed, Injectable, Signal, signal } from '@angular/core';
import { iUser } from '../interfaces/user.interface';

@Injectable({
  providedIn: 'root'
})
export class CurrentUserLoggedStore {
  private user = signal<iUser | null>(null);

  constructor() { }

  public isLoggedIn(): Signal<boolean> {
    return computed(() => this.user() != null)
  }

  public getCurrentUser(): Signal<iUser | null> {
    return computed(() => this.user())
  }

  public logout(): void {
    this.user.set(null)
  }

  public setUser(user: iUser): void {
    this.user.set(user)
  }
}
