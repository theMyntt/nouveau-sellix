import { inject, Injectable } from '@angular/core';
import { API_URL } from '../tokens/api.token';
import { HttpClient } from '@angular/common/http';
import {
  iLoginResponse,
  iRefreshTokenPayload,
  iUser,
  iUserCredentials,
} from '../interfaces/user.interface';
import { map, Observable, of } from 'rxjs';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly apiUrl = inject(API_URL);
  private readonly httpClient = inject(HttpClient);

  constructor() {}

  public login(payload: iUserCredentials): Observable<iLoginResponse> {
    const link = this.apiUrl + '/api/v1/auth';

    return this.httpClient.post<iLoginResponse>(link, payload);
  }

  public refreshToken(payload: iRefreshTokenPayload): Observable<iLoginResponse> {
    const link = this.apiUrl + '/api/v1/auth/refresh'
    return this.httpClient.post<iLoginResponse>(link, payload)
  }

  public getCurrentUserByToken(token: string) {
    return of(jwtDecode<iUser>(token));
  }
}
