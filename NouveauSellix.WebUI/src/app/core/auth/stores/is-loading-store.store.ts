import { Injectable, computed, signal } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class IsLoadingStore {
  private readonly isLoading = signal(false)

  public get() {
    return computed(() => this.isLoading())
  }

  public startLoading() {
    this.isLoading.set(true)
  }

  public stopLoading() {
    this.isLoading.set(false)
  }
}
