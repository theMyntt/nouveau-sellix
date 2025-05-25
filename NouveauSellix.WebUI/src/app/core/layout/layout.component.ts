import { Component, OnInit, effect, inject } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { IsLoadingStore } from '../auth/stores/is-loading-store.store';
import { LoadingComponent } from './components/loading/loading.component';

@Component({
  selector: 'app-layout',
  imports: [HeaderComponent, FooterComponent, MatDialogModule],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {
  private readonly dialog = inject(MatDialog)
  private readonly isLoadingStore = inject(IsLoadingStore)

  protected readonly isLoading = this.isLoadingStore.get()

  public constructor() {
    effect(() => {
      if (this.isLoading()) {
        this.dialog.open(LoadingComponent)
      }
      else {
        this.dialog.closeAll()
      }
    })
  }
}
