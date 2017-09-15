using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Bookcase.BLL.DomainModels;
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
            var mappedBooks = Mapper.Map<List<Book>, List<BookViewModel>>(_bookService.GetAll());
            return View(mappedBooks);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var unmappedBook = _bookService.Get(id);
            var mappedBook = Mapper.Map<Book, BookViewModel>(unmappedBook);

            return PartialView(mappedBook);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookViewModel book)
        {
            var mapCreatedBook = Mapper.Map<BookViewModel, Book>(book);

            _bookService.Create(mapCreatedBook);
            return RedirectToAction("Index");
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var editBook = Mapper.Map<Book, BookViewModel>(_bookService.Get(id.Value));
            return PartialView(editBook);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookViewModel book)
        {
            var mapEditedBook = Mapper.Map<BookViewModel, Book>(book);

            _bookService.Update(mapEditedBook);
            return RedirectToAction("Index");
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var deletedBook = Mapper.Map<Book, BookViewModel>(_bookService.Get(id.Value));

            return PartialView(deletedBook);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(BookViewModel book)
        {
            var mapDeletedBook = Mapper.Map<BookViewModel, Book>(book);
            _bookService.Delete(mapDeletedBook.Id);
            return RedirectToAction("Index");
        }
    }
}