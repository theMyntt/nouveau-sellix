import { Component, inject } from '@angular/core';
import { CurrentUserLoggedStore } from '../../core/auth/stores/current-user-logged-store.store';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-user',
  imports: [MatButtonModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent {
  private readonly currentUserLoggedStore = inject(CurrentUserLoggedStore)

  protected readonly user = this.currentUserLoggedStore.getCurrentUser()
}
