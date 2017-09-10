using AutoMapper;
using Bookcase.BLL.DomainModels;
using Bookcase.ViewModel;

namespace Bookcase.Web.Automapper
{
    public class AutomapperViewModelToDomainProfile : Profile
    {
        public AutomapperViewModelToDomainProfile()
        {
            CreateMap<BookViewModel, Book>()
                .ReverseMap();

            CreateMap<AuthorViewModel, Author>()
                .ReverseMap();
        }
    }
}