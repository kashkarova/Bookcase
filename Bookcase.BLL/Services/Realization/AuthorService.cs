using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.DAL.UoW.Interfaces;
using Bookcase.Domain.DomainModels;

namespace Bookcase.BLL.Services.Realization
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Author Get(int id)
        {
            return _unitOfWork.AuthorRepository.Get(id);
        }

        public List<Author> GetAll()
        {
            var authors = _unitOfWork.AuthorRepository.GetAll().ToList();

            return authors;
        }

        public List<Author> GetAll(Expression<Func<Author, bool>> predicate)
        {
            var authors = _unitOfWork.AuthorRepository.GetAll(predicate).ToList();

            return authors;
        }

        public Author First(Expression<Func<Author, bool>> predicate)
        {
            return _unitOfWork.AuthorRepository.First(predicate);
        }

        public bool Exists(int id)
        {
            return _unitOfWork.AuthorRepository.Exists(id);
        }

        public bool Exists(Expression<Func<Author, bool>> predicate)
        {
            return _unitOfWork.AuthorRepository.Exists(predicate);
        }

        public int Count()
        {
            return _unitOfWork.AuthorRepository.Count();
        }

        public int Count(Expression<Func<Author, bool>> predicate)
        {
            return _unitOfWork.AuthorRepository.Count(predicate);
        }

        public Author Create(Author item)
        {
            var createdAuthor = _unitOfWork.AuthorRepository.Create(item);
            _unitOfWork.Save();

            return createdAuthor;
        }

        public Author Update(Author item)
        {
            var updatedAuthor = _unitOfWork.AuthorRepository.Update(item);
            _unitOfWork.Save();

            return updatedAuthor;
        }

        public void Delete(int id)
        {
            _unitOfWork.AuthorRepository.Delete(id);
            _unitOfWork.Save();
        }


        public void AddBookToAuthor(int bookId, int authorId)
        {
            var book = _unitOfWork.BookRepository.Get(bookId);
            var author = _unitOfWork.AuthorRepository.Get(authorId);

            if (author.Books.Exists(b => b.BookId == book.Id))
            {
                throw new ArgumentException("Invalid book id. Author by that id already contains that book");
            }

            var authorBook = new AuthorBook()
            {
                AuthorId = author.Id,
                BookId = book.Id
            };

            _unitOfWork.AuthorBookRepository.Create(authorBook);
            _unitOfWork.Save();
        }

        public void DeleteBookFromAuthor(int bookId, int authorId)
        {
            var book = _unitOfWork.BookRepository.Get(bookId);
            var author = _unitOfWork.AuthorRepository.Get(authorId);

            if (!author.Books.Exists(b => b.BookId == book.Id))
            {
                throw new ArgumentException("Invalid book id. Author by that id don't contains that book");
            }

            var authorBook =
                _unitOfWork.AuthorBookRepository.First(ab => ab.BookId == book.Id && ab.AuthorId == author.Id);

            _unitOfWork.AuthorBookRepository.Delete(authorBook.Id);
            _unitOfWork.Save();

        }
    }
}