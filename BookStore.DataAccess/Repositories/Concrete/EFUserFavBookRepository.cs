using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFUserFavBookRepository : IUserFavBookRepository
    {
        private BookStoreContext dbContext;

        public EFUserFavBookRepository(BookStoreContext context)
        {
            dbContext = context;
        }
        public UserFavBook Add(UserFavBook entity)
        {
            dbContext.AddAsync(entity);
            dbContext.SaveChangesAsync();
            return entity;
        }


        public UserFavBook Delete(UserFavBook entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChangesAsync();
            return entity;
        }

        public IList<UserFavBook> GetAll(IncludeTypes type)
        {
            IList<UserFavBook> books = IncludeModels(type).ToList();
            return books;
        }

        public IList<UserFavBook> GetByUserId(string id, IncludeTypes type)
        {
            IList<UserFavBook> userFav= IncludeModels(type).ToList();
            return userFav.Where(x => x.AspNetUserId.ToLower().Contains(id.ToLower())).ToList();
        }

        public IList<UserFavBook> GetByUserName(string username, IncludeTypes type)
        {
            IList<UserFavBook> userFav = IncludeModels(type).ToList();
            return userFav.Where(x => x.AspNetUser.UserName.ToLower().Contains(username.ToLower())).ToList();
        }

        public UserFavBook Update(UserFavBook entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChangesAsync();
            return entity;
        }



        private List<UserFavBook> IncludeModels(IncludeTypes paramEnumType)
        {
            var books = dbContext.UserFavBooks;

            if (paramEnumType.HasFlag(IncludeTypes.AspNetUser))
                books.Include(opt => opt.AspNetUser).Load();

            if (paramEnumType.HasFlag(IncludeTypes.Book))
                books.Include(opt => opt.Book).Load();

            return books.ToList();
        }
    }
}
