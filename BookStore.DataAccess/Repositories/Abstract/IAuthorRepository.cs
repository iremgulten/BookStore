using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entities;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IAuthorRepository : IRepository<AuthorsTable>
    {
    }
}
