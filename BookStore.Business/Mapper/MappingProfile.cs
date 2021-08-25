using AutoMapper;
using BookStore.Business.DataTransferObjects;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using BookStore.Entities.BookStoreEntities;
using BookStore.Entities.UserIdentityEntities;

namespace BookStore.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorNameRequest>().ReverseMap();
            CreateMap<Author, GetBooksByAuthorName>().ReverseMap();
            CreateMap<AuthorNameRequest, GetBooksByAuthorName>().ReverseMap();
            CreateMap<Author, AddNewAuthorRequest>().ReverseMap();
            CreateMap<Author, AuthorsListRequest>().ReverseMap();
            CreateMap<Author, EditAuthorRequest>().ReverseMap();
            CreateMap<Author, AuthorName>().ReverseMap();


            CreateMap<Book, AddNewBookRequest>().ReverseMap();
            CreateMap<Book, BookListRequest>().ReverseMap();
            CreateMap<Book, BookFlagsRequest>().ReverseMap();
            CreateMap<Book, EditBookRequest>().ReverseMap();

            CreateMap<Genre, GenreListRequest>().ReverseMap();
            CreateMap<Genre, AddNewGenreRequest>().ReverseMap();
            CreateMap<Genre, EditGenreRequest>().ReverseMap();
            CreateMap<Genre, GenreNameRequest>().ReverseMap();
            CreateMap<GenreNameRequest, AddNewGenreRequest>().ReverseMap();
            CreateMap<Genre, GenreNameDTO>().ReverseMap();


            CreateMap<Publisher, PublisherNameRequest>().ReverseMap();
            CreateMap<Publisher, GetBooksByPublisherName>().ReverseMap();
            CreateMap<PublisherNameRequest, GetBooksByPublisherName>().ReverseMap();
            CreateMap<Publisher, AddNewPublisherRequest>().ReverseMap();
            CreateMap<Publisher, EditPublisherRequest>().ReverseMap();
            CreateMap<Publisher, PublisherListRequest>().ReverseMap();
            CreateMap<Publisher, PublisherNameDTO>().ReverseMap();


            CreateMap<ApplicationUser, UserNameDTO>().ReverseMap();
            CreateMap<Book, BookNameDTO>().ReverseMap();
            CreateMap<Book, BookName>().ReverseMap();
            CreateMap<UserBook, UserFavBookRequest>().ReverseMap();
            CreateMap<UserBook, UserIdDTO>().ReverseMap();
            CreateMap<UserBook, GetByUserNameDTO>().ReverseMap();
            CreateMap<UserBook, GetByUserIdDTO>().ReverseMap();
            CreateMap<UserBook, AddNewFavBook>().ReverseMap();
            CreateMap<UserBook, DeleteUserFav>().ReverseMap();
            
            CreateMap<ComplexAddDTO, Author>().ReverseMap();
            CreateMap<ComplexAddDTO, Genre>().ReverseMap();
            CreateMap<ComplexAddDTO, Publisher>().ReverseMap();
            CreateMap<ComplexAddDTO, Book>().ReverseMap();

            CreateMap<AuthorName, GetBooksByAuthorName>().ReverseMap();






        }
    }
}
