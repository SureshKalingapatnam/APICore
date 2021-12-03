import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit{
  public books: any;
  constructor(private service: BookService) {

  }
  ngOnInit(): void {
    this.getBooks();
  }

  private getBooks(): void {
    this.service.getBooks().subscribe(result => {
      this.books = result;
    });
  }
}


