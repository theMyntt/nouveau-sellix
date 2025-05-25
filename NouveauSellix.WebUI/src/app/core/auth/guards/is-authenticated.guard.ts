import { inject } from '@angular/core';
import { CanActivateFn, RedirectCommand, Router } from '@angular/router';
import { CurrentUserLoggedStore } from '../stores/current-user-logged-store.store';

export const isAuthenticatedGuard: CanActivateFn = (route, state) => {
  const store = inject(CurrentUserLoggedStore)
  const router = inject(Router)

  if (!store.isLoggedIn()) {
    const loginPath = router.parseUrl("/auth/login")
    return new RedirectCommand(loginPath)
  }

  return true;
};
