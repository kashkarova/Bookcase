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
            var mappedAuthors = Mapper.Map<List<Author>, List<AuthorViewModel>>(_bookService.Get(id).Authors);
            return View(mappedAuthors);
        }

        // GET: Book/Create
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(BookViewModel book)
        {
            var mapCreatedBook = Mapper.Map<BookViewModel, Book>(book);

            _bookService.Create(mapCreatedBook);
            return RedirectToAction("Index");
        }

        // GET: Book/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var editBook = Mapper.Map<Book, BookViewModel>(_bookService.Get(id.Value));
            return View(editBook);
        }

        // POST: Book/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(BookViewModel book)
        {
            var mapEditedBook = Mapper.Map<BookViewModel, Book>(book);

            _bookService.Update(mapEditedBook);
            return RedirectToAction("Index");
        }

        // GET: Book/Delete/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var deletedBook = Mapper.Map<Book, BookViewModel>(_bookService.Get(id.Value));

            return View(deletedBook);
        }

        // POST: Book/Delete/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(BookViewModel book)
        {
            var mapDeletedBook = Mapper.Map<BookViewModel, Book>(book);
            _bookService.Delete(mapDeletedBook.Id);
            return RedirectToAction("Index");
        }
    }
}