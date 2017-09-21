using AutoMapper;
using Bookcase.Domain.DomainModels;
using Bookcase.ViewModel;

namespace Bookcase.Web.Automapper
{
    public class AutomapperDomainToViewModelProfile : Profile
    {
        public AutomapperDomainToViewModelProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ReverseMap();

            CreateMap<Author, AuthorViewModel>()
                .ReverseMap();

            CreateMap<AuthorBook, AuthorBookViewModel>()
                .ReverseMap();
        }
    }
}