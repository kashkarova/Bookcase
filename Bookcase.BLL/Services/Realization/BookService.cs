using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Interfaces;
using Bookcase.ViewModel;

namespace Bookcase.BLL.Services.Realization
{
    public class BookService : IBookService
    {
        private readonly IAuthorBookRepository _authorBookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository,
            IAuthorBookRepository authorBookRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorBookRepository = authorBookRepository;
        }

        public BookViewModel Get(int id)
        {
            var unmappedBook = _bookRepository.Get(id);
            var mappedBook = Mapper.Map<Book, BookViewModel>(unmappedBook);

            return mappedBook;
        }

        public List<BookViewModel> GetAll()
        {
            var unmappedBooks = _bookRepository.GetAll().ToList();
            var mappedBooks = Mapper.Map<List<Book>, List<BookViewModel>>(unmappedBooks);

            return mappedBooks;
        }

        public List<BookViewModel> GetAll(Expression<Func<BookViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<BookViewModel, bool>>, Expression<Func<Book, bool>>>(predicate);

            var unmappedBooks = _bookRepository.GetAll(mappedPredicate).ToList();
            var mappedBooks = Mapper.Map<List<Book>, List<BookViewModel>>(unmappedBooks);

            return mappedBooks;
        }

        public BookViewModel First(Expression<Func<BookViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<BookViewModel, bool>>, Expression<Func<Book, bool>>>(predicate);

            var unmappedBook = _bookRepository.First(mappedPredicate);
            var mappedBook = Mapper.Map<Book, BookViewModel>(unmappedBook);

            return mappedBook;
        }

        public bool Exists(int id)
        {
            return _bookRepository.Exists(id);
        }

        public bool Exists(Expression<Func<BookViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<BookViewModel, bool>>, Expression<Func<Book, bool>>>(predicate);

            return _bookRepository.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _bookRepository.Count();
        }

        public int Count(Expression<Func<BookViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<BookViewModel, bool>>, Expression<Func<Book, bool>>>(predicate);

            return _bookRepository.Count(mappedPredicate);
        }

        public BookViewModel Create(BookViewModel item)
        {
            var mappedItem = Mapper.Map<BookViewModel, Book>(item);

            var unmappedBook = _bookRepository.Create(mappedItem);
            _bookRepository.Save();

            var mappedBook = Mapper.Map<Book, BookViewModel>(unmappedBook);

            return mappedBook;
        }

        public BookViewModel Update(BookViewModel item)
        {
            var mappedItem = Mapper.Map<BookViewModel, Book>(item);

            var unmappedBook = _bookRepository.Update(mappedItem);
            _bookRepository.Save();

            var mappedBook = Mapper.Map<Book, BookViewModel>(unmappedBook);

            return mappedBook;
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
            _bookRepository.Save();
        }

        public void AddAuthorToBook(int bookId, int authorId)
        {
            var book = _bookRepository.Get(bookId);
            var author = _authorRepository.Get(authorId);

            var authorBookList = _authorBookRepository.GetAll(b => b.BookId == book.Id);

            if (authorBookList.Any(b => b.AuthorId == author.Id))
                throw new Exception("Error of adding the author! Such author is already exists!");

            var authorBook = new AuthorBook
            {
                AuthorId = author.Id,
                BookId = book.Id
            };

            _authorBookRepository.Create(authorBook);
            _authorBookRepository.Save();
        }

        public void DeleteAuthorFromBook(int bookId, int authorId)
        {
            var book = _bookRepository.Get(bookId);
            var author = _authorRepository.Get(authorId);

            var authorBookList = _authorBookRepository.GetAll(b => b.BookId == book.Id);

            if (!authorBookList.Any(b => b.AuthorId == author.Id))
                throw new ArgumentException("Invalid author id. Book by that id doesn`t contain that author.");

            var authorBook =
                _authorBookRepository.First(ab => ab.BookId == book.Id && ab.AuthorId == author.Id);

            _authorBookRepository.Delete(authorBook.Id);
            _authorBookRepository.Save();
        }
    }
}