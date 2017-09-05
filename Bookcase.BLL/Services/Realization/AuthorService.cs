using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.UoW.Interfaces;

namespace Bookcase.BLL.Services.Realization
{
    public class AuthorService:IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AuthorEntity Get(int id)
        {
            return _unitOfWork.AuthorRepository.Get(id);
        }

        public List<AuthorEntity> GetAll()
        {
            return _unitOfWork.AuthorRepository.GetAll();
        }

        public List<AuthorEntity> GetAll(Expression<Func<AuthorEntity, bool>> predicate)
        {
            return _unitOfWork.AuthorRepository.GetAll(predicate);
        }

        public AuthorEntity First(Expression<Func<AuthorEntity, bool>> predicate)
        {
            return _unitOfWork.AuthorRepository.First(predicate);
        }

        public bool Exists(int id)
        {
            return _unitOfWork.AuthorRepository.Exists(id);
        }

        public bool Exists(Expression<Func<AuthorEntity, bool>> predicate)
        {
            return _unitOfWork.AuthorRepository.Exists(predicate);
        }

        public int Count()
        {
            return _unitOfWork.AuthorRepository.Count();
        }

        public int Count(Expression<Func<AuthorEntity, bool>> predicate)
        {
            return _unitOfWork.AuthorRepository.Count(predicate);
        }

        public void Create(AuthorEntity item)
        {
            _unitOfWork.AuthorRepository.Create(item);
        }

        public void Update(AuthorEntity item)
        {
            _unitOfWork.AuthorRepository.Update(item);
        }

        public void Delete(int id)
        {
            _unitOfWork.AuthorRepository.Delete(id);
        }
    }
}