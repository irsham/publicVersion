import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TableService } from 'src/app/services/tableService';
import { MockTableService } from 'src/app/testing/mock-tableService';
import { TableComponent } from './table';

describe('TableComponent', () => {
  let fixture: ComponentFixture<TableComponent>;
  let comp;
  let compNative;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        MatTableModule,
        MatPaginatorModule,
        MatTabsModule,
        BrowserAnimationsModule,
        FontAwesomeModule,
      ],
      declarations: [TableComponent],
      providers: [
        {
          provide: TableService,
          useClass: MockTableService,
        },
      ],
    }).compileComponents();
    fixture = TestBed.createComponent(TableComponent);
    comp = fixture.debugElement.componentInstance;
    compNative = fixture.debugElement.nativeElement;
    comp.ngOnInit();
    fixture.autoDetectChanges();
  }));

  it('should render table', () => {
    expect(comp).toBeTruthy();
  });
  it('should have column header \'Country\'', () => {
    expect(compNative.querySelector('th').innerHTML).toBe('Country');
  });
  it('should have a data row with image and name', () => {
    expect(
      compNative.querySelector('tbody .mat-column-name').textContent.trim()
    ).toBe('country name');
    expect(compNative.querySelector('.thumbnail')).toBeTruthy();
  });
  it('should expand row on click', () => {
    compNative.querySelector('tbody .mat-column-name').click();
    expect(compNative.querySelector('.example-expanded-row')).toBeTruthy();
  });

  // there can be more tests like checking tabs (number of tabs, their titles and content), pagination row
});
