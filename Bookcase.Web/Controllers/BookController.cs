using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.Domain.DomainModels;
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
            var unmappedBooks = _bookService.GetAll();
            var mappedBooks = Mapper.Map<List<Book>, List<BookViewModel>>(unmappedBooks);

            return View(mappedBooks);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var unmappedBook = _bookService.Get(id);
            var mappedBook = Mapper.Map<Book, BookViewModel>(unmappedBook);

            return PartialView(mappedBook);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel book)
        {
            var mapCreatedBook = Mapper.Map<BookViewModel, Book>(book);

            _bookService.Create(mapCreatedBook);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var unmappedBook = _bookService.Get(id);
            var editBook = Mapper.Map<Book, BookViewModel>(unmappedBook);
            return PartialView(editBook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel book)
        {
            var mapEditedBook = Mapper.Map<BookViewModel, Book>(book);

            _bookService.Update(mapEditedBook);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var unmappedBook = _bookService.Get(id);
            var mappedBook = Mapper.Map<Book, BookViewModel>(unmappedBook);
            _bookService.Delete(mappedBook.Id);

            return RedirectToAction("Index");
        }
    }
}