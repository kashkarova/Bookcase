using System.Linq;
using System.Web.Mvc;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.ViewModel;

namespace Bookcase.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public ActionResult Index()
        {
            var books = _bookService.GetAll();

            return View(books);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var book = _bookService.Get(id);

            var authors = book.Authors.ToList();

            return PartialView(book);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel book, int? authorId)
        {
            var createdBook = _bookService.Create(book);

            if (authorId == null) return RedirectToAction("Index");

            var author = _authorService.Get(authorId.Value);

            _bookService.AddAuthorToBook(createdBook.Id, author.Id);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editBook = _bookService.Get(id);

            return PartialView(editBook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel book)
        {
            _bookService.Update(book);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var deletedBook = _bookService.Get(id);

            _bookService.Delete(deletedBook.Id);

            return RedirectToAction("Index");
        }

        public JsonResult GetAllAuthors()
        {
            var authors = _authorService.GetAll();

            return Json(authors, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthorToBook(int bookId, int authorId)
        {
            _bookService.AddAuthorToBook(bookId, authorId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuthorFromBook(int bookId, int authorId)
        {
            _bookService.DeleteAuthorFromBook(bookId, authorId);

            return RedirectToAction("Index");
        }
    }
}