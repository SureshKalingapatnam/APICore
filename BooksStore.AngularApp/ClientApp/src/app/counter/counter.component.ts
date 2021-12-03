import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BookService } from '../book.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent implements OnInit {

  public bookForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private bookService: BookService) {
    //Constructor inject
  }
  ngOnInit(): void {
    this.init();
  }

  public saveBook(): void {

    this.bookService.addBooks(this.bookForm.value).subscribe(result => {
      alert(`Saved Data = ${JSON.stringify(result)}`);
    });

  }
  private init(): void {

    this.bookForm = this.formBuilder.group({
      title: [],
      description: []
    });
  }

}
