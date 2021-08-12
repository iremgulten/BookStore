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
        void DeleteBook(BookListRequest request);
        int UpdateBook(int id,EditBookRequest request);
        IList<BookListRequest> GetAllBooks();
        BookListRequest GetBooksById(int id);
        public IList<BookFlagsRequest> GetAllBookFlags();
        IList<BookFlagsRequest> GetBooksByAuthor(int authorId);
        IList<BookFlagsRequest> GetBooksByAuthorName(GetBooksByAuthorName author);
        IList<BookFlagsRequest> GetBooksByPublisher(int publisherId);
        IList<BookFlagsRequest> GetBooksByPublisherName(GetBooksByPublisherName publisher);
        IList<BookFlagsRequest> GetBooksByGenre(int genreId);
        IList<BookFlagsRequest> GetBooksByGenreName(EditGenreRequest genre);
    }
}
