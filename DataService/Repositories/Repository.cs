using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repositories
{
    public abstract class Repository
    {
        public abstract IEnumerable<Author> GetAllAuthorsWithBooks();
        public abstract IEnumerable<Author> GetAllAuthors();
        public abstract IEnumerable<Book> GetAllBooksWithVisits();
        public abstract IEnumerable<Book> GetAllBooks();
        public abstract IEnumerable<BookVisit> GetAllBookVisits();

        public abstract IEnumerable<Book> GetAllBooksWithVisits(int authorId);
        public abstract IEnumerable<Book> GetAllBooks(int authorId);
        public abstract IEnumerable<BookVisit> GetAllBookVisits(int bookId);

        public abstract void AddBook(Book book);
        public abstract void AddAuthor(Author author);
        public abstract void AddBookVisit(BookVisit bookVisit);

        public abstract void EditBook(Book book);
        public abstract void EditAuthor(Author author);
        //public abstract void EditBookVisit(BookVisit bookVisit);

        public abstract void DeleteBook(Book book);
        public abstract void DeleteAuthor(Author author);
        public abstract void DeleteBookVisit(BookVisit bookVisit);
    }
}
