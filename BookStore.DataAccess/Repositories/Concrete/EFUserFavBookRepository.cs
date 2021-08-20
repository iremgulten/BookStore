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
        public async Task<UserFavBook> Add(UserFavBook entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<UserFavBook> Delete(UserFavBook entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public IList<UserFavBook> GetAll(IncludeTypes type)
        {
            IList<UserFavBook> books = IncludeModels(type).ToList();
            return books;
        }

        public async Task<UserFavBook> GetByUserId(string id)
        {
            return await dbContext.UserFavBooks.AsNoTracking().FirstOrDefaultAsync(x => x.AspNetUserId == id);
        }

        public async Task<IList<UserFavBook>> GetByUserName(string username)
        {
            return await dbContext.UserFavBooks.AsNoTracking().Where(x => x.AspNetUser.UserName.Contains(username)).ToListAsync();
        }

        public async Task<UserFavBook> Update(UserFavBook entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
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
