using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFPublisherRepository : IPublisherRepository
    {
        private BookStoreContext dbContext;
        public EFPublisherRepository(BookStoreContext context)
        {
            dbContext = context;
        }
        public async Task<Publisher> Add(Publisher entity)
        {
            await dbContext.Publishers.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Publisher> Delete(Publisher entity)
        {
            dbContext.Publishers.Remove(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<Publisher>> GetAll()
        {
            return await dbContext.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetById(int id)
        {
            return await dbContext.Publishers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Publisher> Update(Publisher entity)
        {
            dbContext.Publishers.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
