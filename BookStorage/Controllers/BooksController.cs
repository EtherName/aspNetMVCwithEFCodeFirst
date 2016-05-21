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
            reposit.AddBookVisit(new BookVisit() { ABook = reposit.GetAllBooks().First(x => x.Id == id), Date = DateTime.UtcNow });
            return View(reposit.GetAllBookVisits(id));//reposit.GetAllBookVisits(id).Select(x => new { x.ABook, x.Date, reposit.GetAllBookVisits(id).Count()}));
            //return View(from x in reposit.GetAllBookVisits(id)
            //            //join o in orders on c.ID equals o.ID
            //select new { x.ABook, x.Date, reposit.GetAllBookVisits(id).Count()});
        }

        // GET: Books/Create
        public ActionResult Create(int id)
        {
            ViewData["idAuthor"] = id;
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    reposit.AddBook(book);
                }
                return RedirectToAction("Index", new { id = (int)ViewData["idAuthor"] });
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id) //, authorId = item.AAuthor.Id 
        {
            return View(reposit.GetAllBooks().First(x=> x.Id == id));
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                    reposit.EditBook(book);
                return RedirectToAction("Index", new { id = reposit.GetAllBooks().First(y=>y.Id == book.Id).AAuthor.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View(reposit.GetAllBooks().First(x => x.Id == id));
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                // TODO: Add delete logic here
                reposit.DeleteBook(book);
                return RedirectToAction("Index", new { id = reposit.GetAllBooks().First(y => y.Id == book.Id).AAuthor.Id });
            }
            catch
            {
                return View();
            }
        }
    }
}
