import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxBracketFormComponent } from './tax-bracket.component';

describe('TaxSummaryComponent', () => {
  let component: TaxBracketFormComponent;
  let fixture: ComponentFixture<TaxBracketFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [TaxBracketFormComponent]
    });
    fixture = TestBed.createComponent(TaxBracketFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
