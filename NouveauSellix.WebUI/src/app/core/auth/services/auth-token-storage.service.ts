import { inject, Injectable } from '@angular/core';
import { STORAGE_TOKEN } from '../tokens/storage.token';

@Injectable({
  providedIn: 'root'
})
export class AuthTokenStorageService {
  private readonly storageKey = "auth-token"
  private readonly storage = inject(STORAGE_TOKEN)

  constructor() { }

  public set(token: string): void {
    this.storage.setItem(this.storageKey, token)
  }

  public get(): string | null {
    return this.storage.getItem(this.storageKey)
  }

  public remove(): void {
    this.storage.removeItem(this.storageKey)
  }

  public has(): boolean {
    return this.storage.getItem(this.storageKey) != null
  }
}
