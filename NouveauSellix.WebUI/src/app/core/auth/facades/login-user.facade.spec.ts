import { TestBed } from '@angular/core/testing';

import { LoginUserFacade } from './login-user.facade';

describe('LoginUserFacadeService', () => {
  let service: LoginUserFacade;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoginUserFacade);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
