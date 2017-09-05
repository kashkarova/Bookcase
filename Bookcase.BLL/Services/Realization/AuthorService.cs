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

        public AuthorDTO Get(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, AuthorDTO>());
            return Mapper.Map<AuthorEntity, AuthorDTO>(_unitOfWork.AuthorRepository.Get(id));
        }

        public List<AuthorDTO> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, AuthorDTO>());
            return Mapper.Map<List<AuthorEntity>, List<AuthorDTO>>(_unitOfWork.AuthorRepository.GetAll());
        }

        public List<AuthorDTO> GetAll(Expression<Func<AuthorEntity, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, AuthorDTO>());
            return Mapper.Map<List<AuthorEntity>, List<AuthorDTO>>(_unitOfWork.AuthorRepository.GetAll(predicate));
        }

        public AuthorDTO First(Expression<Func<AuthorEntity, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorEntity, AuthorDTO>());
            return Mapper.Map<AuthorEntity, AuthorDTO>(_unitOfWork.AuthorRepository.First(predicate));
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
            _unitOfWork.Save();
        }

        public void Update(AuthorEntity item)
        {
            _unitOfWork.AuthorRepository.Update(item);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.AuthorRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}