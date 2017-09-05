using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Bookcase.BLL.DTO;
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

        public BookDTO Get(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, BookDTO>());
            return Mapper.Map<BookEntity, BookDTO>(_unitOfWork.BookRepository.Get(id));
        }

        public List<BookDTO> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, BookDTO>()); 
            return Mapper.Map<List<BookEntity>, List<BookDTO>>(_unitOfWork.BookRepository.GetAll());
        }

        public List<BookDTO> GetAll(Expression<Func<BookEntity, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, BookDTO>());
            return Mapper.Map<List<BookEntity>, List<BookDTO>>(_unitOfWork.BookRepository.GetAll(predicate));
        }

        public BookDTO First(Expression<Func<BookEntity, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, BookDTO>());
            return Mapper.Map<BookEntity, BookDTO>(_unitOfWork.BookRepository.First(predicate));
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
            _unitOfWork.Save();
        }

        public void Update(BookEntity item)
        {
            _unitOfWork.BookRepository.Update(item);
            _unitOfWork.Save();
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