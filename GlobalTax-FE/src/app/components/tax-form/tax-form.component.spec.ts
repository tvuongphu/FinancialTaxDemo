import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxFormComponent } from './tax-form.component';

describe('TaxFormComponent', () => {
  let component: TaxFormComponent;
  let fixture: ComponentFixture<TaxFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [TaxFormComponent]
    });
    fixture = TestBed.createComponent(TaxFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
