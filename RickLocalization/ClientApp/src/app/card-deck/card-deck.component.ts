import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { CardModel } from '.././shared/models/card.model';
import { CardDeckService } from './card-deck.service';

import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-card-deck',
  templateUrl: './card-deck.component.html',
  styleUrls: ['./card-deck.component.css']
})
export class CardDeckComponent implements OnInit {    
  
  public cardsDisplayed: CardModel[];

  public array: any;
  public displayedColumns = ['', '', '', '', ''];
  public dataSource: any;

  public pageSize = 10;
  public currentPage = 0;
  public totalSize = 0;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private cardDeckService: CardDeckService) { }  

  ngOnInit() {
    this.getListaCards()    
  };

  public geraPaginacao(e: any) {
    this.currentPage = e.pageIndex;
    this.pageSize = e.pageSize;
    this.filtraPagina();
  }

  getListaCards() {

    this.cardDeckService.getCards()
      .subscribe(
        ((data: CardModel[]) => {
          this.dataSource = new MatTableDataSource<CardModel>(data);
          this.dataSource.paginator = this.paginator;
          this.array = data;
          this.totalSize = this.array.length;
          this.filtraPagina();
          this.cardsDisplayed = data;          
        })
      );
  }

  private filtraPagina() {
    const end = (this.currentPage + 1) * this.pageSize;
    const start = this.currentPage * this.pageSize;
    const part = this.array.slice(start, end);
    this.dataSource = part;
    this.cardsDisplayed = this.dataSource;
  }
}


