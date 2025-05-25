import { inject, Injectable } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AuthTokenStorageService } from '../services/auth-token-storage.service';
import { CurrentUserLoggedStore } from '../stores/current-user-logged-store.store';
import { catchError, of, pipe, switchMap, tap } from 'rxjs';
import { iUserCredentials } from '../interfaces/user.interface';
import { iError } from '../interfaces/error.interface';

@Injectable({
  providedIn: 'root'
})
export class LoginUserFacade {
  private readonly authStore = inject(CurrentUserLoggedStore)
  private readonly authService = inject(AuthService)
  private readonly authTokenStorageService = inject(AuthTokenStorageService)

  constructor() { }

  public login(payload: iUserCredentials) {
    return this.authService.login(payload).pipe(
      this.createSession(),
      catchError((err) => of(err.error as iError))
    )
  }

  public refreshToken() {
    if (!this.authTokenStorageService.has()) return of()

    var token = this.authTokenStorageService.get()!

    return this.authService.refreshToken({
      oldToken: token
    }).pipe(
      this.createSession()
    )
  }

  private createSession() {
    return pipe(
      tap({ next: ({ token }) => this.authTokenStorageService.set(token) }),
      switchMap(({ token }) => this.authService.getCurrentUserByToken(token)),
      tap({ next: (user) => this.authStore.setUser(user) })
    )
  }
}
