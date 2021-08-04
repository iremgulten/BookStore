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
    }
}
