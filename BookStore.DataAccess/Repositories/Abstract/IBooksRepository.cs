using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Concrete;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IBooksRepository 
    {
        IList<Book> GetAll(IncludeTypes type);
        Book GetById(int id, IncludeTypes type);
        Book Add(Book entity);
        Book Update(Book entity);
        Book Delete(Book entity);
        public IList<Book> GetAllBookFlags(IncludeTypes type);
        public IList<Book> GetByAuthor(int id, IncludeTypes type);
        public IList<Book> GetBooksByAuthorName(string author, IncludeTypes type);
        public IList<Book> GetByPublisher(int id, IncludeTypes type);
        public IList<Book> GetBooksByPublisherName(string publisher, IncludeTypes type);
        public IList<Book> GetByGenre(int id, IncludeTypes type);
        public IList<Book> GetBooksByGenreName(string genre, IncludeTypes type);
    }
}
