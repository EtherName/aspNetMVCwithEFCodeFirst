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
        int _id = 0;
        // GET: Books
        public ActionResult Index(int id)
        {
            //reposit.GetAllBooks(id);
            _id = id;
            return View(reposit.GetAllBooks(_id));
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            reposit.AddBookVisit(new BookVisit() { ABook = reposit.GetAllBooks().First(x => x.Id == id), Date = DateTime.Now });
            return View(reposit.GetAllBookVisits(id));//reposit.GetAllBookVisits(id).Select(x => new { x.ABook, x.Date, reposit.GetAllBookVisits(id).Count()}));
            //return View(from x in reposit.GetAllBookVisits(id)
            //            //join o in orders on c.ID equals o.ID
            //select new { x.ABook, x.Date, reposit.GetAllBookVisits(id).Count()});
        }

        // GET: Books/Create
        public ActionResult Create()
        {
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
                    book.AAuthor = reposit.GetAllAuthors().First(x => x.Id == _id);
                    reposit.AddBook(book);
                }
                return RedirectToAction("Index", new { id = _id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
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
                return RedirectToAction("Index", new { id = _id });
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
                return RedirectToAction("Index", new { id = _id });
            }
            catch
            {
                return View();
            }
        }
    }
}
