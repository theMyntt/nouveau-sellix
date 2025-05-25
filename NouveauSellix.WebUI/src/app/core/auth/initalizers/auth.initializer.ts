import { inject } from "@angular/core"
import { AuthTokenStorageService } from "../services/auth-token-storage.service"
import { AuthService } from "../services/auth.service"
import { CurrentUserLoggedStore } from "../stores/current-user-logged-store.store"
import { lastValueFrom } from "rxjs"

export const authInitializerFactory = () => {
    return async () => {
        const currentUserLoggedStore = inject(CurrentUserLoggedStore)
        const authTokenStorageService = inject(AuthTokenStorageService)
        const authService = inject(AuthService)
        
        if (!authTokenStorageService.has()) {
            return
        }
        
        const token = authTokenStorageService.get()!
        const user = await lastValueFrom(authService.getCurrentUserByToken(token))

        currentUserLoggedStore.setUser(user)
    }
}