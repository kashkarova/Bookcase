using Bookcase.BLL.DTO;
using Bookcase.ViewModel;
using AutoMapper;

namespace Bookcase.Infrastructure.MappingModels
{
    public class AutomapperViewModelToDomainProfile : Profile
    {
        public AutomapperViewModelToDomainProfile()
        {
            CreateMap<BookViewModel, Book>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Title, src => src.MapFrom(x => x.Title))
                .ForMember(dst => dst.Year, src => src.MapFrom(x => x.Year))
                .ForMember(dst => dst.PublishingHouse, src => src.MapFrom(x => x.PublishingHouse))
                .ForMember(dst => dst.Authors, src => src.MapFrom(x => x.Authors));

            CreateMap<Book, BookViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Title, src => src.MapFrom(x => x.Title))
                .ForMember(dst => dst.Year, src => src.MapFrom(x => x.Year))
                .ForMember(dst => dst.PublishingHouse, src => src.MapFrom(x => x.PublishingHouse))
                .ForMember(dst => dst.Authors, src => src.MapFrom(x => x.Authors));

            CreateMap<AuthorViewModel, Author>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dst => dst.DateOfBirth, src => src.MapFrom(x => x.DateOfBirth))
                .ForMember(dst => dst.Country, src => src.MapFrom(x => x.Country))
                .ForMember(dst => dst.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dst => dst.Books, src => src.MapFrom(x => x.Books));

            CreateMap<Author, AuthorViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dst => dst.DateOfBirth, src => src.MapFrom(x => x.DateOfBirth))
                .ForMember(dst => dst.Country, src => src.MapFrom(x => x.Country))
                .ForMember(dst => dst.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dst => dst.Books, src => src.MapFrom(x => x.Books));
        }
    }
}
