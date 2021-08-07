using AutoMapper;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Entities;

namespace BookStore.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorNameResponse>().ReverseMap();
            CreateMap<Author, GetBooksByAuthorName>().ReverseMap();
            CreateMap<AuthorNameResponse, GetBooksByAuthorName>().ReverseMap();
            CreateMap<Author, AddNewAuthorRequest>().ReverseMap();
            CreateMap<Author, AuthorsListResponse>().ReverseMap();
            CreateMap<Author, DeleteAuthorRequest>().ReverseMap();
            CreateMap<Author, EditAuthorRequest>().ReverseMap();

            CreateMap<Book, AddNewBookRequest>().ReverseMap();
            CreateMap<Book, BooksListResponse>().ReverseMap();
            CreateMap<Book, BookFlagsResponse>().ReverseMap();
            CreateMap<Book, EditBookRequest>().ReverseMap();
            CreateMap<Book, DeleteBookRequest>().ReverseMap();
            CreateMap<DeleteBookRequest, BooksListResponse>().ReverseMap();

            CreateMap<Genre, GenreListResponse>().ReverseMap();
            CreateMap<Genre, AddNewGenreRequest>().ReverseMap();
            CreateMap<Genre, EditGenreRequest>().ReverseMap();
            CreateMap<Genre, GenreNameResponse>().ReverseMap();
            CreateMap<GenreNameResponse, AddNewGenreRequest>().ReverseMap();

            CreateMap<Publisher, PublisherNameResponse>().ReverseMap();
            CreateMap<Publisher, GetBooksByPublisherName>().ReverseMap();
            CreateMap<PublisherNameResponse, GetBooksByPublisherName>().ReverseMap();



        }
    }
}
