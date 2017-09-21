using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.DAL.UoW.Interfaces;
using Bookcase.Domain.DomainModels;

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
            return _unitOfWork.BookRepository.Get(id);
        }

        public List<Book> GetAll()
        {
            return _unitOfWork.BookRepository.GetAll().ToList();
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> predicate)
        {
            return _unitOfWork.BookRepository.GetAll(predicate).ToList();
        }

        public Book First(Expression<Func<Book, bool>> predicate)
        {
            return _unitOfWork.BookRepository.First(predicate);
        }

        public bool Exists(int id)
        {
            return _unitOfWork.BookRepository.Exists(id);
        }

        public bool Exists(Expression<Func<Book, bool>> predicate)
        {
            return _unitOfWork.BookRepository.Exists(predicate);
        }

        public int Count()
        {
            return _unitOfWork.BookRepository.Count();
        }

        public int Count(Expression<Func<Book, bool>> predicate)
        {
            return _unitOfWork.BookRepository.Count(predicate);
        }

        public Book Create(Book item)
        {
            var createdBook = _unitOfWork.BookRepository.Create(item);
            _unitOfWork.Save();

            return createdBook;
        }

        public Book Update(Book item)
        {
            var updatedBook = _unitOfWork.BookRepository.Update(item);
            _unitOfWork.Save();

            return updatedBook;
        }

        public void Delete(int id)
        {
            _unitOfWork.BookRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}