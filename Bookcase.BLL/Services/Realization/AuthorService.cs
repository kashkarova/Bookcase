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
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Author Get(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, Author>().ReverseMap());
            return Mapper.Map<AuthorEntity, Author>(_unitOfWork.AuthorRepository.Get(id));
        }

        public List<Author> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, Author>().ReverseMap());
            return Mapper.Map<List<AuthorEntity>, List<Author>>(_unitOfWork.AuthorRepository.GetAll());
        }

        public List<Author> GetAll(Expression<Func<Author, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, Author>().ReverseMap());
            var mappedPredicate =
                Mapper.Map<Expression<Func<Author, bool>>, Expression<Func<AuthorEntity, bool>>>(predicate);

            return Mapper.Map<List<AuthorEntity>, List<Author>>(_unitOfWork.AuthorRepository.GetAll(mappedPredicate));
        }

        public Author First(Expression<Func<Author, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, Author>().ReverseMap());
            var mappedPredicate =
                Mapper.Map<Expression<Func<Author, bool>>, Expression<Func<AuthorEntity, bool>>>(predicate);

            return Mapper.Map<AuthorEntity, Author>(_unitOfWork.AuthorRepository.First(mappedPredicate));
        }

        public bool Exists(int id)
        {
            return _unitOfWork.AuthorRepository.Exists(id);
        }

        public bool Exists(Expression<Func<Author, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, Author>().ReverseMap());
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
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, Author>().ReverseMap());
            var mappedPredicate =
                Mapper.Map<Expression<Func<Author, bool>>, Expression<Func<AuthorEntity, bool>>>(predicate);

            return _unitOfWork.AuthorRepository.Count(mappedPredicate);
        }

        public void Create(Author item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BookEntity, Author>().ReverseMap());

            var mappedAuthor = Mapper.Map<Author, AuthorEntity>(item);

            _unitOfWork.AuthorRepository.Create(mappedAuthor);
            _unitOfWork.Save();
        }

        public void Update(Author item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, Author>().ReverseMap());
            var mappedAuthor = Mapper.Map<Author, AuthorEntity>(item);

            _unitOfWork.AuthorRepository.Update(mappedAuthor);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.AuthorRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}