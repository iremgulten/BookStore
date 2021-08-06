using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entities;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IBooksRepository : IRepository<BooksTable>
    {
        public IList<BooksTable> GetAllBookFlags();
        public IList<BooksTable> GetByAuthor(int id);
        public IList<BooksTable> GetBooksByAuthorName(string author);
        public IList<BooksTable> GetByPublisher(int id);
        public IList<BooksTable> GetBooksByPublisherName(string publisher);
        public IList<BooksTable> GetByGenre(int id);
        public IList<BooksTable> GetBooksByGenreName(string genre);
    }
}
