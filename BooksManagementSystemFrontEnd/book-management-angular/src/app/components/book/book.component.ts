import { Component, OnInit } from '@angular/core';
import { Book } from '../../models/book.model';
import { BookService } from '../../services/book.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  books: Book[] = [];
  newBook: Book = { id: 0, title: '', author: '', isbn: '', publicationDate: '' };
  editing: boolean = false;

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    this.bookService.getBooks().subscribe(data => this.books = data);
  }

  addBook(): void {
    this.bookService.addBook(this.newBook).subscribe(() => {
      this.loadBooks();
      this.newBook = { id: 0, title: '', author: '', isbn: '', publicationDate: '' };
    });
  }

  deleteBook(id: number): void {
    this.bookService.deleteBook(id).subscribe(() => this.loadBooks());
  }

  updateBook(book: Book): void {
    this.newBook = { ...book };
    this.editing = true;
  }

  saveChanges(): void {
  this.bookService.updateBook(this.newBook).subscribe(() => {
    this.loadBooks();
    this.newBook = { id: 0, title: '', author: '', isbn: '', publicationDate: '' };
    this.editing = false;
  });
}

  
}
