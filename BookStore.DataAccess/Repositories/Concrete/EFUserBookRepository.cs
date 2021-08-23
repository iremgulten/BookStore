using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFUserBookRepository : IUserBookRepository
    {
        private BookStoreContext dbContext;

        public EFUserBookRepository(BookStoreContext context)
        {
            dbContext = context;
        }
        public UserBook Add(UserBook entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }
        public UserBook Delete(UserBook entity)
        {
            dbContext.UserBooks.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public IList<UserBook> GetAll(IncludeTypes type)
        {
            //    IList<UserBook> books = IncludeModels(type).ToList();
            //    return books;
            return dbContext.UserBooks.Include(o => o.Book).Include(p => p.User).ToList();
        }
        public UserBook GetById(int id, IncludeTypes type)
        {
            IList<UserBook> userFav = IncludeModels(type).ToList();
            return userFav.FirstOrDefault();
        }

        public IList<UserBook> GetByUserId(string id, IncludeTypes type)
        {
            IList<UserBook> userFav = IncludeModels(type).ToList();
            return userFav.Where(x => x.UserId.ToLower().Contains(id.ToLower())).ToList();
        }

        public IList<UserBook> GetByUserName(string username, IncludeTypes type)
        {
            IList<UserBook> userFav = IncludeModels(type).ToList();
            return userFav.Where(x => x.User.UserName.ToLower().Contains(username.ToLower())).ToList();
        }
        private List<UserBook> IncludeModels(IncludeTypes paramEnumType)
        {
            var books = dbContext.UserBooks;

            //if (paramEnumType.HasFlag(IncludeTypes.User))
            //    books.Include(opt => opt.User).Load();

            if (paramEnumType.HasFlag(IncludeTypes.Book))
                books.Include(opt => opt.Book).Load();

            return books.ToList();
        }
    }
}
