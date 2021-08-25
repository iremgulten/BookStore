using System.Collections.Generic;
using System.Linq;
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
        public UserBook Delete(int id)
        {
            var userFav = dbContext.UserBooks.Find(id);
            dbContext.UserBooks.Remove(userFav);
            dbContext.SaveChanges();
            return userFav;
        }

        public IList<UserBook> GetAll(IncludeTypes type)
        {
            IList<UserBook> books = IncludeModels(type,1).ToList();
            return books;
        }
        public UserBook GetById(int id, IncludeTypes type)
        {
            IList<UserBook> userFav = IncludeModels(type,1).ToList();
            return userFav.FirstOrDefault();
        }

        public IList<UserBook> GetByUserId(string id, IncludeTypes type)
        {
            IList<UserBook> userFav = IncludeModels(type,1).ToList();
            return userFav.Where(x => x.UserId.ToLower().Contains(id.ToLower())).ToList();
        }

        public IList<UserBook> GetByUserName(string username, IncludeTypes type)
        {
            IList<UserBook> userFav = IncludeModels(type,1).ToList();
            return userFav.Where(x => x.User.UserName.ToLower().Contains(username.ToLower())).ToList();
        }
        private List<UserBook> IncludeModels(IncludeTypes paramEnumType,int temp)
        {
            var books = dbContext.UserBooks;

            if (paramEnumType.HasFlag(IncludeTypes.User))
                books.Include(opt => opt.User).Load();

            if (paramEnumType.HasFlag(IncludeTypes.Book))
                books.Include(opt => opt.Book).Load();

            if(temp == 1)
            {
                books.AsNoTracking();
            }

            return books.ToList();
        }
    }
}
