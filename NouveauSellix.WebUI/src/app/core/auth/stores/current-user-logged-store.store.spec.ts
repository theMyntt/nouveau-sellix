import { TestBed } from '@angular/core/testing';

import { CurrentUserLoggedStoreService } from './current-user-logged-store.store';

describe('CurrentUserLoggedStoreService', () => {
  let service: CurrentUserLoggedStoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurrentUserLoggedStoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
