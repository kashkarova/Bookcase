using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Bookcase.BLL.DomainModels;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.UoW.Interfaces;

namespace Bookcase.BLL.Services.Realization
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Book Get(int id)
        {
            var unmappedBook = _unitOfWork.BookRepository.Get(id);
            var mappedBook = Mapper.Map<BookEntity, Book>(unmappedBook);

            return mappedBook;
        }

        public List<Book> GetAll()
        {
            var unmappedBooks = _unitOfWork.BookRepository.GetAll();

            var mappedBooks = Mapper.Map<List<BookEntity>, List<Book>>(unmappedBooks);

            return mappedBooks;
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<Book, bool>>, Expression<Func<BookEntity, bool>>>(predicate);

            var mappedBooks =
                Mapper.Map<List<BookEntity>, List<Book>>(_unitOfWork.BookRepository.GetAll(mappedPredicate));

            return mappedBooks;
        }

        public Book First(Expression<Func<Book, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<Book, bool>>, Expression<Func<BookEntity, bool>>>(predicate);

            var mappedBook = Mapper.Map<BookEntity, Book>(_unitOfWork.BookRepository.First(mappedPredicate));

            return mappedBook;
        }

        public bool Exists(int id)
        {
            return _unitOfWork.BookRepository.Exists(id);
        }

        public bool Exists(Expression<Func<Book, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<Book, bool>>, Expression<Func<BookEntity, bool>>>(predicate);

            return _unitOfWork.BookRepository.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _unitOfWork.BookRepository.Count();
        }

        public int Count(Expression<Func<Book, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<Book, bool>>, Expression<Func<BookEntity, bool>>>(predicate);

            return _unitOfWork.BookRepository.Count(mappedPredicate);
        }

        public Book Create(Book item)
        {
            var mappedBook = Mapper.Map<Book, BookEntity>(item);

            var createdBook = _unitOfWork.BookRepository.Create(mappedBook);
            _unitOfWork.Save();

            return Mapper.Map<BookEntity, Book>(createdBook);
        }

        public Book Update(Book item)
        {
            var mappedBook = Mapper.Map<Book, BookEntity>(item);

            var updatedBook = _unitOfWork.BookRepository.Update(mappedBook);
            _unitOfWork.Save();

            return Mapper.Map<BookEntity, Book>(updatedBook);
        }

        public void Delete(int id)
        {
            _unitOfWork.BookRepository.Delete(id);
            _unitOfWork.Save();
        }

        public void AddAuthorToBook(int bookId, int authorId)
        {
            var book = _unitOfWork.BookRepository.Get(bookId);
            var author = _unitOfWork.AuthorRepository.Get(authorId);

            book.Authors.Add(author);
            _unitOfWork.Save();
        }

        public void DeleteAuthorFromBook(int bookId, int authorId)
        {
            var book = _unitOfWork.BookRepository.Get(bookId);
            var author = _unitOfWork.AuthorRepository.Get(authorId);

            book.Authors.Remove(author);
            _unitOfWork.Save();
        }
    }
}