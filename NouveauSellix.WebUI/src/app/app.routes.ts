import { Routes } from '@angular/router';
import { isAuthenticatedGuard } from './core/auth/guards/is-authenticated.guard';
import { AuthComponent } from './features/auth/auth.component';
import { isNotAuthenticatedGuard } from './core/auth/guards/is-not-authenticated.guard';

export const routes: Routes = [
  {
    path: 'home',
    canActivate: [isAuthenticatedGuard],
    children: [
      {
        path: '',
        loadChildren: () => import('./features/home/routes').then(m => m.routes)
      }
    ]
  },
  {
    path: 'user',
    canActivate: [isAuthenticatedGuard],
    children: [
      {
        path: '',
        loadChildren: () => import('./features/user/routes').then(m => m.routes)
      }
    ]
  },
  {
    path: 'auth',
    canActivate: [isNotAuthenticatedGuard],
    children: [
      {
        path: '',
        loadChildren: () => import('./features/auth/routes').then(m => m.routes)
      }
    ]
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: 'home'
  }
];
