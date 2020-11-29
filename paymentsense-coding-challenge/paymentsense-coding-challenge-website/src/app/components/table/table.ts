import { Component, OnInit, ViewChild } from '@angular/core';
import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { TableService } from 'src/app/services';
import { Country } from 'src/app/models';

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table',
  styleUrls: ['table.css'],
  templateUrl: 'table.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition(
        'expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')
      ),
    ]),
  ],
})
export class TableComponent implements OnInit {
  dataSource: MatTableDataSource<Country>;
  columnsToDisplay = ['name'];

  // Hash used to get the name of the country for its code
  countryWithCode = {};

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(public tableService: TableService) {
    this.dataSource = new MatTableDataSource();
  }

  async ngOnInit() {
    this.dataSource = new MatTableDataSource(
      await this.tableService.getCountryList()
    );
    this.dataSource.paginator = this.paginator;

    // Hash is updated
    this.dataSource.data.forEach((el) => {
      this.countryWithCode[el.alpha3Code] = el.name;
    });
  }
}
