using AutoMapper;
using Bookcase.BLL.DomainModels;
using Bookcase.DAL.DbEntities;

namespace Bookcase.BLL.Automapper
{
    public class AutomapperEFToDomainProfile : Profile
    {
        public AutomapperEFToDomainProfile()
        {
            CreateMap<BookEntity, Book>()
                .ReverseMap();

            CreateMap<AuthorEntity, Author>()
                .ReverseMap();
        }
    }
}