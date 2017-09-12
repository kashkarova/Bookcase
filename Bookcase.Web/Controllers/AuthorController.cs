using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Bookcase.BLL.DomainModels;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.ViewModel;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Bookcase.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Author
        public ActionResult Index()
        {
            var mappedAuthors = Mapper.Map<List<Author>, List<AuthorViewModel>>(_authorService.GetAll());

            return View(mappedAuthors);
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
        public ActionResult Create(AuthorViewModel author)
        {
            var mapCreatedAuthor = Mapper.Map<AuthorViewModel, Author>(author);

            _authorService.Create(mapCreatedAuthor);

            return RedirectToAction("Index");
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var editAuthor = Mapper.Map<Author, AuthorViewModel>(_authorService.Get(id.Value));
            return View(editAuthor);
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(AuthorViewModel author)
        {
            var mapEditedAuthor = Mapper.Map<AuthorViewModel, Author>(author);

            _authorService.Update(mapEditedAuthor);
            return RedirectToAction("Index");
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var deletedAuthor = Mapper.Map<Author, AuthorViewModel>(_authorService.Get(id.Value));

            return View(deletedAuthor);
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(AuthorViewModel author)
        {
            var mapDeletedAuthor = Mapper.Map<AuthorViewModel, Author>(author);
            _authorService.Delete(mapDeletedAuthor.Id);
            return RedirectToAction("Index");
        }
    }
}