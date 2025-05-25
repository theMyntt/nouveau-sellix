import { Component, inject, OnInit, signal } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { CurrentUserLoggedStore } from '../../../auth/stores/current-user-logged-store.store';
import { iUser } from '../../../auth/interfaces/user.interface';
import { Router, RouterModule } from '@angular/router';
import { MatMenuModule } from '@angular/material/menu'
import { LogoutUserFacade } from '../../../auth/facades/logout-user.facade';

@Component({
  selector: 'app-header',
  imports: [MatToolbarModule, MatButtonModule, RouterModule, MatMenuModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent{
  private readonly currentUserLoggedStore = inject(CurrentUserLoggedStore);
  private readonly logoutFacade = inject(LogoutUserFacade)
  private readonly router = inject(Router)

  protected readonly user = this.currentUserLoggedStore.getCurrentUser()
  protected readonly isLogged = this.currentUserLoggedStore.isLoggedIn()

  protected logout() {
    this.logoutFacade.logout().subscribe(() => {
      this.router.navigate(["/auth/login"])
    })
  }
}
