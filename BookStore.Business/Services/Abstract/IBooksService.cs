using System.Collections.Generic;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Entities;

namespace BookStore.Business.Services.Abstract
{
    public interface IBooksService
    {

        int AddBook(AddNewBookRequest request);
        void DeleteBook(BooksListResponse request);
        int UpdateBook(EditBookRequest request);
        IList<BooksListResponse> GetAllBooks();
        BooksListResponse GetBooksById(int id);
        public IList<BookFlagsResponse> GetAllBookFlags();
        IList<BookFlagsResponse> GetBooksByAuthor(int authorId);
        IList<BookFlagsResponse> GetBooksByAuthorName(string author);
        IList<BookFlagsResponse> GetBooksByPublisher(int publisherId);
        IList<BookFlagsResponse> GetBooksByPublisherName(string publisher);
        IList<BookFlagsResponse> GetBooksByGenre(int genreId);
        IList<BookFlagsResponse> GetBooksByGenreName(string genre);


    }
}
