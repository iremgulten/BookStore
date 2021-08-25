using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFGenreRepository : IGenreRepository
    {
        private BookStoreContext genreContext;

        public EFGenreRepository(BookStoreContext context)
        {
            genreContext = context;
        }

        public async Task<Genre> Add(Genre entity)
        {
            await genreContext.Genres.AddAsync(entity);
            await genreContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Genre> Delete(Genre entity)
        {
            genreContext.Genres.Remove(entity);
            await genreContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IList<Genre>> GetAll()
        {
            return await genreContext.Genres.ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            return await genreContext.Genres.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Genre> Update(Genre entity)
        {
            genreContext.Genres.Update(entity);
            await genreContext.SaveChangesAsync();
            return entity;
        }
    }
}
