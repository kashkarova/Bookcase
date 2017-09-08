using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Bookcase.BLL.DTO;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.ViewModel;

namespace Bookcase.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            var boo = Mapper.Map<List<Book>, List<BookViewModel>>(_bookService.GetAll());
            return View(boo);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookViewModel book)
        {
            try
            {
                var createBook = Mapper.Map<BookViewModel, Book>(book);

                _bookService.Create(createBook);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var editBook = Mapper.Map<Book, BookViewModel>(_bookService.Get(id.Value));
            return View(editBook);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookViewModel book)
        {
            var editedBook = Mapper.Map<BookViewModel, Book>(book);

            _bookService.Update(editedBook);
            return RedirectToAction("Index");
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}