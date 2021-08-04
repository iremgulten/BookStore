using System.Collections.Generic;
using BookStore.Business.DataTransferObjects;
using BookStore.Models;

namespace BookStore.Business.Services.Abstract
{
    public interface IBooksService
    {
        IList<BooksFlag> GetAllBooksFlag();

        int AddBook(AddNewBookRequest request);
        BooksListResponse GetBooksById(int id);
        int UpdateBook(EditBookRequest request);
        void DeleteBook(BooksListResponse request);
    }
}
