﻿using AutoMapper;
using Bookcase.DAL.DbEntities;
using Bookcase.ViewModel;

namespace Bookcase.BLL.Automapper
{
    public class AutomapperEFToDomainProfile : Profile
    {
        public AutomapperEFToDomainProfile()
        {
            CreateMap<Author, AuthorViewModel>()
                .MaxDepth(1)
                .ReverseMap();

            CreateMap<Book, BookViewModel>()
                .MaxDepth(1)
                .ReverseMap();

            CreateMap<AuthorBook, AuthorBookViewModel>()
                .MaxDepth(1)
                .ReverseMap();
        }
    }
}