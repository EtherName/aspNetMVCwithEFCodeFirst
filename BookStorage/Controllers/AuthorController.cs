using DataService.Entities;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStorage.Controllers
{
    public class AuthorController : Controller
    {
        Repository reposit { get; set; } = RepositoryFactory.GetRepository();
        // GET: Author
        public ActionResult Index()
        {
            return View(reposit.GetAllAuthors());
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                    reposit.AddAuthor(author);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View(reposit.GetAllAuthors().First(x => x.Id == id));
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                    reposit.EditAuthor(author);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View(reposit.GetAllAuthors().First(x => x.Id == id));
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                    reposit.DeleteAuthor(author);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
