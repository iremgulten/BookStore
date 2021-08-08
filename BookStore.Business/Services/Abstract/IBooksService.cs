using System.Collections.Generic;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Entities;

namespace BookStore.Business.Services.Abstract
{
    public interface IBooksService
    {

        int AddBook(AddNewBookRequest request);
        void DeleteBook(BooksListResponse request);
        int UpdateBook(int id,EditBookRequest request);
        IList<BooksListResponse> GetAllBooks();
        BooksListResponse GetBooksById(int id);
        public IList<BookFlagsResponse> GetAllBookFlags();
        IList<BookFlagsResponse> GetBooksByAuthor(int authorId);
        IList<BookFlagsResponse> GetBooksByAuthorName(GetBooksByAuthorName author);
        IList<BookFlagsResponse> GetBooksByPublisher(int publisherId);
        IList<BookFlagsResponse> GetBooksByPublisherName(GetBooksByPublisherName publisher);
        IList<BookFlagsResponse> GetBooksByGenre(int genreId);
        IList<BookFlagsResponse> GetBooksByGenreName(EditGenreRequest genre);
    }
}
