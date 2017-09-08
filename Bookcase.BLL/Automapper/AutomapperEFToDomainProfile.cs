using AutoMapper;
using Bookcase.BLL.DTO;
using Bookcase.DAL.DbEntities;

namespace Bookcase.BLL.Automapper
{
    public class AutomapperEFToDomainProfile : Profile
    {
        public AutomapperEFToDomainProfile()
        {
            CreateMap<BookEntity, Book>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Title, src => src.MapFrom(x => x.Title))
                .ForMember(dst => dst.Year, src => src.MapFrom(x => x.Year))
                .ForMember(dst => dst.PublishingHouse, src => src.MapFrom(x => x.PublishingHouse))
                .ForMember(dst=>dst.Authors, src => src.MapFrom(x => x.Authors));

            CreateMap<Book, BookEntity>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Title, src => src.MapFrom(x => x.Title))
                .ForMember(dst => dst.Year, src => src.MapFrom(x => x.Year))
                .ForMember(dst => dst.PublishingHouse, src => src.MapFrom(x => x.PublishingHouse))
                .ForMember(dst => dst.Authors, src => src.MapFrom(x => x.Authors));

            CreateMap<AuthorEntity, Author>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dst => dst.DateOfBirth, src => src.MapFrom(x => x.DateOfBirth))
                .ForMember(dst => dst.Country, src => src.MapFrom(x => x.Country))
                .ForMember(dst => dst.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dst=>dst.Books, src => src.MapFrom(x => x.Books));

            CreateMap<Author, AuthorEntity>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dst => dst.DateOfBirth, src => src.MapFrom(x => x.DateOfBirth))
                .ForMember(dst => dst.Country, src => src.MapFrom(x => x.Country))
                .ForMember(dst => dst.Photo, src => src.MapFrom(x => x.Photo))
                .ForMember(dst => dst.Books, src => src.MapFrom(x => x.Books));
        }
    }
}