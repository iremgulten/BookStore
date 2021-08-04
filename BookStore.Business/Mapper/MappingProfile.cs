using AutoMapper;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Models;

namespace BookStore.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorsTable, AuthorNameResponse>().ReverseMap();

            CreateMap<BooksTable, AddNewBookRequest>().ReverseMap();
            CreateMap<BooksTable, BooksListResponse>().ReverseMap();
            CreateMap<BooksTable, BookFlagsResponse>().ReverseMap();
            CreateMap<BooksTable, EditBookRequest>().ReverseMap();

            CreateMap<GenresTable, GenreListResponse>().ReverseMap();
            CreateMap<GenresTable, AddNewGenreRequest>().ReverseMap();
            CreateMap<GenresTable, EditGenreRequest>().ReverseMap();
            CreateMap<GenresTable, GenreNameResponse>().ReverseMap();


            CreateMap<PublishersTable, PublisherNameResponse>().ReverseMap();

        }
    }
}
