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
        private BookStoreContext authorContext;

        public EFAuthorRepository(BookStoreContext context)
        {
            authorContext = context;
        }
        public async Task<Author> Add(Author entity)
        {
            await authorContext.Authors.AddAsync(entity);
            await authorContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Author> Delete(Author entity)
        {
            authorContext.Authors.Remove(entity);
            await authorContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<Author>> GetAll()
        {
            return await authorContext.Authors.ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            return await authorContext.Authors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Author> Update(Author entity)
        {
            authorContext.Authors.Update(entity);
            await authorContext.SaveChangesAsync();
            return entity;
        }
    }
}
