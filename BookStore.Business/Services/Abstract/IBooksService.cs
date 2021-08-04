using System.Collections.Generic;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Models;

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
        IList<BooksListResponse> GetBooksByAuthor(int authorId);
        IList<BooksListResponse> GetBooksByPublisher(int publisherId);
        IList<BooksListResponse> GetBooksByGenre(int genreId);

    }
}
