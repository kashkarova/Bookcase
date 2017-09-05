using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.UoW.Interfaces;

namespace Bookcase.BLL.Services.Realization
{
    public class BookService:IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BookEntity Get(int id)
        {
            return _unitOfWork.BookRepository.Get(id);
        }

        public List<BookEntity> GetAll()
        {
            return _unitOfWork.BookRepository.GetAll();
        }

        public List<BookEntity> GetAll(Expression<Func<BookEntity, bool>> predicate)
        {
            return _unitOfWork.BookRepository.GetAll(predicate);
        }

        public BookEntity First(Expression<Func<BookEntity, bool>> predicate)
        {
            return _unitOfWork.BookRepository.First(predicate);
        }

        public bool Exists(int id)
        {
            return _unitOfWork.BookRepository.Exists(id);
        }

        public bool Exists(Expression<Func<BookEntity, bool>> predicate)
        {
            return _unitOfWork.BookRepository.Exists(predicate);
        }

        public int Count()
        {
            return _unitOfWork.BookRepository.Count();
        }

        public int Count(Expression<Func<BookEntity, bool>> predicate)
        {
            return _unitOfWork.BookRepository.Count(predicate);
        }

        public void Create(BookEntity item)
        {
            _unitOfWork.BookRepository.Create(item);
        }

        public void Update(BookEntity item)
        {
            _unitOfWork.BookRepository.Update(item);
        }

        public void Delete(int id)
        {
            _unitOfWork.BookRepository.Delete(id);
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