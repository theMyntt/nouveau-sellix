import { Component, inject, signal } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon'
import { LoginUserFacade } from '../../core/auth/facades/login-user.facade';
import { MatDialog, MatDialogModule } from '@angular/material/dialog'
import { iUserCredentials } from '../../core/auth/interfaces/user.interface';
import { Router } from '@angular/router';
import { iError } from '../../core/auth/interfaces/error.interface';
import { ErrorDialogComponent } from './components/error-dialog/error-dialog.component';

@Component({
  selector: 'app-auth',
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatDialogModule],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss',
})
export class AuthComponent {
  private readonly loginFacade = inject(LoginUserFacade)
  private readonly router = inject(Router)
  private readonly dialog = inject(MatDialog)
  private readonly fb = inject(FormBuilder)

  protected isTryingToAuth = signal<boolean>(false)
  protected showPassword = signal<boolean>(false)
  protected loginForm = this.fb.group({
    email: this.fb.control('', [Validators.required, Validators.email]),
    password: this.fb.control('', [
      Validators.required,
      Validators.minLength(6),
    ]),
  });

  protected updateShowPassword(event: Event) {
    this.showPassword.update(value => !value)
  }

  protected login() {
    if (this.loginForm.invalid) {
      return
    }

    this.isTryingToAuth.set(true)
    const { email, password } = this.loginForm.value
    const credentials: iUserCredentials = {
      email: email ?? "",
      password: password ?? ""
    }

    this.loginFacade.login(credentials).subscribe((res) => {
      this.isTryingToAuth.set(false)
      if ("message" in res) {
        this.handleApiError(res)
        return
      }

      this.router.navigate(["/home"])
    })
  }

  private handleApiError(res: iError) {
    this.dialog.open(ErrorDialogComponent, {
      data: {
        errorMessage: res.message
      }
    })
  }
}
