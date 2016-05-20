using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Entities;

namespace DataService.Repositories
{
    internal class BookStorageRepositoty : Repository
    {
        private BookStorageDBContext context = new BookStorageDBContext();

        public override IEnumerable<Author> GetAllAuthorsWithBooks()
        {
            return context.Authors.Include("Books").ToList();
        }
        public override IEnumerable<Author> GetAllAuthors()
        {
            return context.Authors.ToList();
        }
        public override IEnumerable<Book> GetAllBooksWithVisits()
        {
            return context.Books.Include("BookVisits").ToList();
        }
        public override IEnumerable<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }
        public override IEnumerable<BookVisit> GetAllBookVisits()
        {
            return context.BookVisits.ToList();
        }

        public override IEnumerable<Book> GetAllBooksWithVisits(int authorId)
        {
            return context.Books.Include("BookVisits").Where(x=> x.AAuthor.Id == authorId).ToList();
        }
        public override IEnumerable<Book> GetAllBooks(int authorId)
        {
            return context.Books.Where(x => x.AAuthor.Id == authorId).ToList();
        }
        public override IEnumerable<BookVisit> GetAllBookVisits(int bookId)
        {
            return context.BookVisits.Where(x => x.ABook.Id == bookId).ToList();
        }

        public override void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }
        public override void AddAuthor(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }
        public override void AddBookVisit(BookVisit bookVisit)
        {
            context.BookVisits.Add(bookVisit);
            context.SaveChanges();
        }

        public override void EditBook(Book book)
        {
            context.Books.First(x => x.Id == book.Id).ISBN = book.ISBN;
            context.Books.First(x => x.Id == book.Id).Title = book.Title;
            context.Books.First(x => x.Id == book.Id).Years = book.Years;
            //var _book = context.Books.First(x => x.Id == book.Id);
            //_book.ISBN = book.ISBN;
            //_book.Title = book.Title;
            //_book.Years = book.Years;
            context.SaveChanges();
        }
        public override void EditAuthor(Author author)
        {
            var _author = context.Authors.First(x => x.Id == author.Id && x.FirstName == author.FirstName && x.LastName == author.LastName);
            _author.FirstName = author.FirstName;
            _author.LastName = author.LastName;
            context.SaveChanges();
        }
        //public override void EditBookVisit(BookVisit bookVisit)
        //{
        //    var _bookVisit = context.BookVisits.First(x => x.Id == bookVisit.Id);
        //    _bookVisit.Quantity += 1;
        //    _bookVisit.Date = DateTime.Now;
        //    context.SaveChanges();
        //}

        public override void DeleteBook(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }
        public override void DeleteAuthor(Author author)
        {
            context.Authors.Remove(author);
            context.SaveChanges();
        }
        public override void DeleteBookVisit(BookVisit bookVisit)
        {
            context.BookVisits.Remove(bookVisit);
            context.SaveChanges();
        }
    }
}
