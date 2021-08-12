using System.Collections.Generic;
using System.Linq;
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
        public Author Add(Author entity)
        {
            dbContext.Authors.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(Author entity)
        {
            dbContext.Authors.Remove(entity);
            dbContext.SaveChanges();
        }

        public IList<Author> GetAll()
        {
            return dbContext.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return dbContext.Authors.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Author Update(Author entity)
        {
            dbContext.Authors.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
