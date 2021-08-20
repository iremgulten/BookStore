using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFGenreRepository : IGenreRepository
    {
        private BookStoreContext dbContext;

        public EFGenreRepository(BookStoreContext context)
        {
            dbContext = context;
        }

        public async Task<Genre> Add(Genre entity)
        {
            await dbContext.Genres.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Genre> Delete(Genre entity)
        {
            dbContext.Genres.Remove(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IList<Genre>> GetAll()
        {
            return await dbContext.Genres.ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            return await dbContext.Genres.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Genre> Update(Genre entity)
        {
            dbContext.Genres.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
