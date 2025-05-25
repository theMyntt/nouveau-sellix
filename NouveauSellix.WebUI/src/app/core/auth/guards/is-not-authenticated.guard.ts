import { CanActivateFn, RedirectCommand, Router } from "@angular/router";
import { AuthTokenStorageService } from "../services/auth-token-storage.service";
import { inject } from "@angular/core";

export const isNotAuthenticatedGuard: CanActivateFn = () => {
  const store = inject(AuthTokenStorageService)
  const router = inject(Router)

  if (store.has()) {
    const loginPath = router.parseUrl("/home")
    return new RedirectCommand(loginPath)
  }

  return true;
}
