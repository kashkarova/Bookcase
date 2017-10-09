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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public AuthorViewModel Get(int id)
        {
            var unmappedAuthor = _authorRepository.Get(id);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);

            return mappedAuthor;
        }

        public List<AuthorViewModel> GetAll()
        {
            var unmappedAuthors = _authorRepository.GetAll().ToList();
            var mappedAuthors = Mapper.Map<List<Author>, List<AuthorViewModel>>(unmappedAuthors);

            return mappedAuthors;
        }

        public List<AuthorViewModel> GetAll(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            var unmappedAuthors = _authorRepository.GetAll(mappedPredicate).ToList();
            var mappedAuthors = Mapper.Map<List<Author>, List<AuthorViewModel>>(unmappedAuthors);

            return mappedAuthors;
        }

        public AuthorViewModel First(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            var unmappedAuthor = _authorRepository.First(mappedPredicate);
            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);

            return mappedAuthor;
        }

        public bool Exists(int id)
        {
            return _authorRepository.Exists(id);
        }

        public bool Exists(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            return _authorRepository.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _authorRepository.Count();
        }

        public int Count(Expression<Func<AuthorViewModel, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<AuthorViewModel, bool>>, Expression<Func<Author, bool>>>(predicate);

            return _authorRepository.Count(mappedPredicate);
        }

        public AuthorViewModel Create(AuthorViewModel item)
        {
            var unmapItem = Mapper.Map<AuthorViewModel, Author>(item);

            var unmappedAuthor = _authorRepository.Create(unmapItem);
            _authorRepository.Save();

            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);

            return mappedAuthor;
        }

        public AuthorViewModel Update(AuthorViewModel item)
        {
            var unmapItem = Mapper.Map<AuthorViewModel, Author>(item);

            var unmappedAuthor = _authorRepository.Update(unmapItem);
            _authorRepository.Save();

            var mappedAuthor = Mapper.Map<Author, AuthorViewModel>(unmappedAuthor);

            return mappedAuthor;
        }

        public void Delete(int id)
        {
            _authorRepository.Delete(id);
            _authorRepository.Save();
        }
    }
}