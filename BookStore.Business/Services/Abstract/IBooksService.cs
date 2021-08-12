using System.Collections.Generic;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;

namespace BookStore.Business.Services.Abstract
{
    public interface IBooksService
    {

        void AddBook(AddNewBookRequest request);
        void DeleteBook(BookListRequest request);
        void UpdateBook(EditBookRequest request);
        IList<BookListRequest> GetAllBooks();
        BookListRequest GetBooksById(int id);
        IList<BookFlagsRequest> GetAllBookFlags();
        BookFlagsRequest GetBookFlagById(int id);
        IList<BookFlagsRequest> GetBooksByAuthor(int authorId);
        IList<BookFlagsRequest> GetBooksByAuthorName(GetBooksByAuthorName author);
        IList<BookFlagsRequest> GetBooksByPublisher(int publisherId);
        IList<BookFlagsRequest> GetBooksByPublisherName(GetBooksByPublisherName publisher);
        IList<BookFlagsRequest> GetBooksByGenre(int genreId);
        IList<BookFlagsRequest> GetBooksByGenreName(GenreNameRequest genre);
    }
}
