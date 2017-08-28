using System.Collections.Generic;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.IBookcase;

namespace Bookcase.BLL.Services
{
    public class Author
    {
        private readonly IGenericRepository<AuthorEntity> _repository;

        public IEnumerable<AuthorEntity> GetAllAuthors()
        {
            return _repository.GetAll();
        }

        public AuthorEntity GetAuthor(int authorId)
        {
            return _repository.GetObject(authorId);
        }

        public void CreateAuthor(AuthorEntity author)
        {
            _repository.Create(author);
        }


        public void UpdateAuthor(AuthorEntity author)
        {
            _repository.Update(author);
        }

        public void DeleteAuthor(int authorId)
        {
            _repository.Delete(authorId);
        }

        public void SaveAuthor()
        {
            _repository.Save();
        }
    }
}