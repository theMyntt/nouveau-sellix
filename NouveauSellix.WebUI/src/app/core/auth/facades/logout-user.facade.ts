import { inject, Injectable } from "@angular/core";
import { AuthTokenStorageService } from "../services/auth-token-storage.service";
import { CurrentUserLoggedStore } from "../stores/current-user-logged-store.store";
import { of, pipe, tap } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class LogoutUserFacade {
    private readonly authTokenStorageService = inject(AuthTokenStorageService)
    private readonly currentUserLoggedStore = inject(CurrentUserLoggedStore)

    public logout() {
        return of(true).pipe(
            tap({ next: () => this.authTokenStorageService.remove() }),
            tap({ next: () => this.currentUserLoggedStore.logout() })
        );
    }
}