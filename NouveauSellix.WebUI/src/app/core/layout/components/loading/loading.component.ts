import { Component } from "@angular/core";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";

@Component({
  selector: 'app-loading',
  imports: [MatProgressSpinnerModule],
  template: `
    <mat-spinner></mat-spinner>
  `,
  styles: [
    `
      :host {
        display: flex;
        justify-content: center;
        align-items: center;
        padding: 20px;
        mat-spinner {
          width: 50px !important;
        }
      }
    `
  ]
})
export class LoadingComponent {

}
