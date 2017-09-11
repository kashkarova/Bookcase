using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Bookcase.BLL.DomainModels;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.UoW.Interfaces;

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
            var unmappedAuthor = _unitOfWork.AuthorRepository.Get(id);
            var mappedAuthor = Mapper.Map<AuthorEntity, Author>(unmappedAuthor);

            return mappedAuthor;
        }

        public List<Author> GetAll()
        {
            var unmappedAuthors = _unitOfWork.AuthorRepository.GetAll();
            var mappedAuthors = Mapper.Map<List<AuthorEntity>, List<Author>>(unmappedAuthors);

            return mappedAuthors;
        }

        public List<Author> GetAll(Expression<Func<Author, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<Author, bool>>, Expression<Func<AuthorEntity, bool>>>(predicate);

            var mappedAuthors =
                Mapper.Map<List<AuthorEntity>, List<Author>>(_unitOfWork.AuthorRepository.GetAll(mappedPredicate));

            return mappedAuthors;
        }

        public Author First(Expression<Func<Author, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<Author, bool>>, Expression<Func<AuthorEntity, bool>>>(predicate);

            var mappedAuthor = Mapper.Map<AuthorEntity, Author>(_unitOfWork.AuthorRepository.First(mappedPredicate));

            return mappedAuthor;
        }

        public bool Exists(int id)
        {
            return _unitOfWork.AuthorRepository.Exists(id);
        }

        public bool Exists(Expression<Func<Author, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<Author, bool>>, Expression<Func<AuthorEntity, bool>>>(predicate);

            return _unitOfWork.AuthorRepository.Exists(mappedPredicate);
        }

        public int Count()
        {
            return _unitOfWork.AuthorRepository.Count();
        }

        public int Count(Expression<Func<Author, bool>> predicate)
        {
            var mappedPredicate =
                Mapper.Map<Expression<Func<Author, bool>>, Expression<Func<AuthorEntity, bool>>>(predicate);

            return _unitOfWork.AuthorRepository.Count(mappedPredicate);
        }

        public Author Create(Author item)
        {
            var mappedAuthor = Mapper.Map<Author, AuthorEntity>(item);

            var createdAuthor = _unitOfWork.AuthorRepository.Create(mappedAuthor);
            _unitOfWork.Save();

            return Mapper.Map<AuthorEntity, Author>(createdAuthor);
        }

        public Author Update(Author item)
        {
            var mappedAuthor = Mapper.Map<Author, AuthorEntity>(item);

            var updatedAuthor = _unitOfWork.AuthorRepository.Update(mappedAuthor);
            _unitOfWork.Save();

            return Mapper.Map<AuthorEntity, Author>(updatedAuthor);
        }

        public void Delete(int id)
        {
            _unitOfWork.AuthorRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}