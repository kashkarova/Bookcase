using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Bookcase.BLL.DomainModels;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.ViewModel;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Bookcase.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
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

        public ActionResult AddAuthorToBook(int bookId, int authorId)
        {
            var book = _bookService.Get(bookId);
            var mappedBook = Mapper.Map<Book, BookViewModel>(book);

            var author = _authorService.Get(authorId);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(author);

            if (mappedBook.Authors.Exists(a => a.Id == mappedAuthor.Id))
            {
                ModelState.AddModelError("Error", "This author is exists");
            }

            if (ModelState.IsValid)
            {
                _bookService.AddAuthorToBook(mappedBook.Id, mappedAuthor.Id);
                RedirectToAction("Index");
            }
            ViewBag.Message = "Error";

            return View(mappedBook);
        }

        public ActionResult DeleteAuthorFromBook(int bookId, int authorId)
        {
            var book = _bookService.Get(bookId);
            var mappedBook = Mapper.Map<Book, BookViewModel>(book);

            var author = _authorService.Get(authorId);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(author);

            if (!mappedBook.Authors.Exists(a => a.Id == mappedAuthor.Id))
            {
                ModelState.AddModelError("Error", "This author isn`t exists");
            }

            if (ModelState.IsValid)
            {
                _bookService.DeleteAuthorFromBook(mappedBook.Id, mappedAuthor.Id);
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Error";

            return View(mappedBook);
        }

        public JsonResult GetAllAuthors()
        {
            var authors = _authorService.GetAll();
            var mappedAuthors = Mapper.Map<List<Author>, List<AuthorViewModel>>(authors);

            //TODO: Automapper.MaxDepth not working
            foreach (var author in mappedAuthors)
            {
                author.Books = null;
            }

            return Json(mappedAuthors, JsonRequestBehavior.AllowGet);
        }
    }
}