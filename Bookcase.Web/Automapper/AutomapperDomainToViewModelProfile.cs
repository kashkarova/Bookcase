using AutoMapper;
using Bookcase.BLL.DomainModels;
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
        }
    }
}