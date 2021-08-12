using System.Collections.Generic;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IBooksRepository : IRepository<Book>
    {
        public IList<Book> GetAllBookFlags();
        public IList<Book> GetByAuthor(int id);
        public IList<Book> GetBooksByAuthorName(string author);
        public IList<Book> GetByPublisher(int id);
        public IList<Book> GetBooksByPublisherName(string publisher);
        public IList<Book> GetByGenre(int id);
        public IList<Book> GetBooksByGenreName(string genre);
    }
}
