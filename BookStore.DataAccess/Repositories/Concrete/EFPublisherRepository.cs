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
        private BookStoreContext publisherContext;
        public EFPublisherRepository(BookStoreContext context)
        {
            publisherContext = context;
        }
        public async Task<Publisher> Add(Publisher entity)
        {
            await publisherContext.Publishers.AddAsync(entity);
            await publisherContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Publisher> Delete(Publisher entity)
        {
            publisherContext.Publishers.Remove(entity);
            await publisherContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<Publisher>> GetAll()
        {
            return await publisherContext.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetById(int id)
        {
            return await publisherContext.Publishers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Publisher> Update(Publisher entity)
        {
            publisherContext.Publishers.Update(entity);
            await publisherContext.SaveChangesAsync();
            return entity;
        }
    }
}
