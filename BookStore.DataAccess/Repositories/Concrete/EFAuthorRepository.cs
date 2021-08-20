using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFAuthorRepository : IAuthorRepository
    {
        private BookStoreContext dbContext;

        public EFAuthorRepository(BookStoreContext context)
        {
            dbContext = context;
        }
        public async Task<Author> Add(Author entity)
        {
            await dbContext.Authors.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Author> Delete(Author entity)
        {
            dbContext.Authors.Remove(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<Author>> GetAll()
        {
            return await dbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            return await dbContext.Authors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Author> Update(Author entity)
        {
            dbContext.Authors.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
