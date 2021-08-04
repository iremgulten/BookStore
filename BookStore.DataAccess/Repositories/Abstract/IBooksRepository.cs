using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IBooksRepository : IRepository<BooksTable>
    {
        public IList<BooksTable> GetAllBookFlags();
        public IList<BooksTable> GetByAuthor(int id);
        public IList<BooksTable> GetByPublisher(int id);
        public IList<BooksTable> GetByGenre(int id);

    }
}
