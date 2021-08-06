using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
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
        public AuthorsTable Add(AuthorsTable entity)
        {
            dbContext.AuthorsTables.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(AuthorsTable entity)
        {
            var deletedBook = dbContext.BooksTables.FirstOrDefault(x => x.AuthorId == entity.Id);
            dbContext.BooksTables.Remove(deletedBook);
            dbContext.AuthorsTables.Remove(entity);
            dbContext.SaveChanges();
        }

        public IList<AuthorsTable> GetAll()
        {
            return dbContext.AuthorsTables.ToList();
        }

        public AuthorsTable GetById(int id)
        {
            return dbContext.AuthorsTables.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public AuthorsTable Update(AuthorsTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
