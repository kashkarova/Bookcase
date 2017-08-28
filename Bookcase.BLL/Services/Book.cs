using System.Collections.Generic;
using System.Linq;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.IBookcase;

namespace Bookcase.BLL.Services
{
    public class Book
    {
        private readonly IGenericRepository<BookEntity> _repository;

        public IEnumerable<BookEntity> GetAllBooks()
        {
            return _repository.GetAll();
        }

        public IEnumerable<BookEntity> GetBooksByAuthor(AuthorEntity author)
        {
            return _repository.GetAll().Where(book => book.Authors.Contains(author));
        }

        public BookEntity GetBook(int bookId)
        {
            return _repository.GetObject(bookId);
        }

        public void CreateBook(BookEntity book)
        {
            _repository.Create(book);
        }

        public void UpdateBook(BookEntity book)
        {
            _repository.Update(book);
        }

        public void DeleteBook(int bookId)
        {
            _repository.Delete(bookId);
        }

        public void SaveBook()
        {
            _repository.Save();
        }
    }
}