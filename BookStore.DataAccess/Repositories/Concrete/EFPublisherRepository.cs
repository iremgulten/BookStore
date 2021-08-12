using System.Collections.Generic;
using System.Linq;
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
        public Publisher Add(Publisher entity)
        {
            dbContext.Publishers.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(Publisher entity)
        {
            dbContext.Publishers.Remove(entity);
            dbContext.SaveChanges();
        }

        public IList<Publisher> GetAll()
        {
            return dbContext.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            return dbContext.Publishers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Publisher Update(Publisher entity)
        {
            dbContext.Publishers.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
