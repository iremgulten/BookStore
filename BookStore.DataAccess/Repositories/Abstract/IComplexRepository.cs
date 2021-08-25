using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IComplexRepository
    {
        void Add(Author author, Publisher publisher, Genre genre,Book book);
    }
}
