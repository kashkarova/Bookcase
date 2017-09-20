﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Bookcase.BLL.DomainModels;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.ViewModel;

namespace Bookcase.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AuthorController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            var mappedAuthors = Mapper.Map<List<Author>, List<AuthorViewModel>>(_authorService.GetAll());

            return View(mappedAuthors);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var unmappedAuthor = _authorService.Get(id);

            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);
            var mappedAuthorBooks = mappedAuthor.Books.Select(b => b.Id);

            SetViewDataWithBooks(mappedAuthorBooks);
            return PartialView(mappedAuthor);
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
            var mapCreatedAuthor = Mapper.Map<AuthorViewModel, Author>(author);

            _authorService.Create(mapCreatedAuthor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var unmappedAuthor = _authorService.Get(id);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);
            return PartialView(mappedAuthor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorViewModel author)
        {
            var mapEditedAuthor = Mapper.Map<AuthorViewModel, Author>(author);

            _authorService.Update(mapEditedAuthor);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var unmappedAuthor = _authorService.Get(id);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);

            _authorService.Delete(mappedAuthor.Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBookToAuthor(int authorId, int bookId)
        {
            var unmappedAuthor = _authorService.Get(authorId);
            var unmappedBook = _bookService.Get(bookId);

            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);
            var mappedBook = Mapper.Map<Book, BookViewModel>(unmappedBook);

            _authorService.AddBookToAuthor(mappedBook.Id, mappedAuthor.Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBookFromAuthor(int authorId, int bookId)
        {
            var unmappedAuthor = _authorService.Get(authorId);
            var unmappedBook = _bookService.Get(bookId);

            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);
            var mappedBook = Mapper.Map<Book, BookViewModel>(unmappedBook);

            _authorService.DeleteBookFromAuthor(mappedBook.Id, mappedAuthor.Id);

            return RedirectToAction("Index");
        }

        private void SetViewDataWithBooks(IEnumerable<int> excludedBooksId)
        {
            var excludedBooksList = excludedBooksId.ToList();
            var unmappedBooks = _bookService.GetAll(b => excludedBooksList.All(eb => eb != b.Id));

            var books = new SelectList(unmappedBooks, "Id", "Title");

            ViewData["books"] = books;
        }
    }
}