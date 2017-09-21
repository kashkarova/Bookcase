using AutoMapper;
using Bookcase.DAL.DbEntities;
using Bookcase.Domain.DomainModels;

namespace Bookcase.BLL.Automapper
{
    public class AutomapperEFToDomainProfile : Profile
    {
        public AutomapperEFToDomainProfile()
        {
            CreateMap<AuthorEntity, Author>()
                .MaxDepth(1)
                .ReverseMap();

            CreateMap<BookEntity, Book>()
                .MaxDepth(1)
                .ReverseMap();

            CreateMap<AuthorBookEntity, AuthorBook>()
                .MaxDepth(1)
                .ReverseMap();
        }
    }
}