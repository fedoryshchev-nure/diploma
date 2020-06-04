import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommendationsListItemComponent } from './recommendations-list-item.component';

describe('RecommendationsListItemComponent', () => {
  let component: RecommendationsListItemComponent;
  let fixture: ComponentFixture<RecommendationsListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecommendationsListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecommendationsListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
