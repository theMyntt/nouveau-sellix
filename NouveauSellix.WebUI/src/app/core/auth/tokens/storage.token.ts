import { InjectionToken } from "@angular/core";

export const STORAGE_TOKEN = new InjectionToken<Storage>('Storage', {
    providedIn: 'root',
    factory: () => {
        if (typeof window !== 'undefined' && window.localStorage) {
            return window.localStorage;
        }

        return {
            length: 0,
            clear: () => { },
            getItem: () => null,
            key: () => null,
            removeItem: () => { },
            setItem: () => { },
        } as Storage;
    }
});