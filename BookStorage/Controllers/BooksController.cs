using DataService.Entities;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStorage.Controllers
{
    public class BooksController : Controller
    {
        //RepositoryFactory rf { get; set; } = new RepositoryFactory();
        Repository reposit { get; set; } = RepositoryFactory.GetRepository();
        // GET: Books
        public ActionResult Index(int id)
        {
            ViewData["idAuthor"] = id;
            return View(reposit.GetAllBooks(id));
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            reposit.AddBookVisit(new BookVisit() { ABook = reposit.GetAllBooks().First(x => x.Id == id), Date = DateTime.UtcNow.Date });
            return View(reposit.GetAllBooks().First(x=>x.Id == id));
        }

        // GET: Books/Create
        public ActionResult Create(int id)
        {
            ViewData["idAuthor"] = id;
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(int id, Book book)
        {
            try
            {
                // TODO: Add insert logic here
                ViewData["idAuthor"] = id;
                if (ModelState.IsValid)
                    reposit.AddBook(new Book() {Id= book.Id, ISBN=book.ISBN, Title=book.Title, Years=book.Years, AAuthor= reposit.GetAllAuthors().First(x => x.Id == id) });
                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id, int authorId)
        {
            return View(reposit.GetAllBooks().First(x=> x.Id == id));
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book, int authorId)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                    reposit.EditBook(book);
                return RedirectToAction("Index", new { id = authorId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id, int authorId)
        {
            ViewData["idAuthor"] = id;
            return View(reposit.GetAllBooks().First(x => x.Id == id));
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book book, int authorId)
        {
            try
            {
                // TODO: Add delete logic here
                ViewData["idAuthor"] = authorId;
                reposit.DeleteBook(reposit.GetAllBooks().First(y => y.Id == book.Id));
                return RedirectToAction("Index", new { id = authorId });
            }
            catch
            {
                return View();
            }
        }
    }
}
