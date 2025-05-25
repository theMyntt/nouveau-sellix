import { inject } from '@angular/core';
import { CanActivateFn, RedirectCommand, Router } from '@angular/router';
import { AuthTokenStorageService } from '../services/auth-token-storage.service';

export const isAuthenticatedGuard: CanActivateFn = (route, state) => {
  const store = inject(AuthTokenStorageService)
  const router = inject(Router)

  if (!store.has()) {
    const loginPath = router.parseUrl("/auth/login")
    return new RedirectCommand(loginPath)
  }

  return true;
};
