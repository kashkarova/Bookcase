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

        public Book Get(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, Book>().ReverseMap());
            return Mapper.Map<BookEntity, Book>(_unitOfWork.BookRepository.Get(id));
        }

        public List<Book> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, Book>().ReverseMap());
            var unmappedList = _unitOfWork.BookRepository.GetAll();

            var listOfBooks = Mapper.Map<List<BookEntity>, List<Book>>(unmappedList);

            return listOfBooks;
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, Book>().ReverseMap());
            var mappedPredicate =
                Mapper.Map<Expression<Func<Book, bool>>, Expression<Func<BookEntity, bool>>>(predicate);
            return Mapper.Map<List<BookEntity>, List<Book>>(_unitOfWork.BookRepository.GetAll(mappedPredicate));
        }

        public Book First(Expression<Func<Book, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, Book>().ReverseMap());
            var mappedPredicate =
                Mapper.Map<Expression<Func<Book, bool>>, Expression<Func<BookEntity, bool>>>(predicate);

            return Mapper.Map<BookEntity, Book>(_unitOfWork.BookRepository.First(mappedPredicate));
        }

        public bool Exists(int id)
        {
            return _unitOfWork.BookRepository.Exists(id);
        }

        public bool Exists(Expression<Func<Book, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, Book>().ReverseMap());
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
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, Book>().ReverseMap());
            var mappedPredicate =
                Mapper.Map<Expression<Func<Book, bool>>, Expression<Func<BookEntity, bool>>>(predicate);

            return _unitOfWork.BookRepository.Count(mappedPredicate);
        }

        public void Create(Book item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, Book>().ReverseMap());

            var mappedBook = Mapper.Map<Book, BookEntity>(item);

            _unitOfWork.BookRepository.Create(mappedBook);
            _unitOfWork.Save();
        }

        public void Update(Book item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, Book>().ReverseMap());

            var mappedBook = Mapper.Map<Book, BookEntity>(item);

            _unitOfWork.BookRepository.Update(mappedBook);
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