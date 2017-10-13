using System.Web.Mvc;
using Bookcase.BLL.Filters;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.ViewModel;

namespace Bookcase.Web.Controllers
{
    [ExceptionFilter]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public ActionResult Index()
        {
            var authors = _authorService.GetAll();

            return View(authors);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var author = _authorService.Get(id);

            return PartialView(author);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel author)
        {
            _authorService.Create(author);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editedAuthor = _authorService.Get(id);

            return PartialView(editedAuthor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorViewModel author)
        {
            _authorService.Update(author);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var deletedAuthor = _authorService.Get(id);

            _authorService.Delete(deletedAuthor.Id);

            return RedirectToAction("Index");
        }
    }
}