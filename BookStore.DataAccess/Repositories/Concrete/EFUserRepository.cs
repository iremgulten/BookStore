using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private BookStoreContext dbContext;

        public EFUserRepository(BookStoreContext context)
        {
            dbContext = context;
        }
        public UsersTable Add(UsersTable entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UsersTable entity)
        {
            throw new NotImplementedException();
        }

        public IList<UsersTable> GetAll()
        {
            return dbContext.UsersTables.ToList();
        }

        public UsersTable GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<UsersTable> GetWithCriteria(Func<UsersTable, bool> criteria)
        {
            return dbContext.UsersTables.Where(criteria).ToList();
        }

        public UsersTable Update(UsersTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
