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
        public Author Add(Author entity)
        {
            dbContext.Authors.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(Author entity)
        {
            var deletedBook = dbContext.Books.FirstOrDefault(x => x.AuthorId == entity.Id);
            dbContext.Books.Remove(deletedBook);
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
            throw new NotImplementedException();
        }
    }
}
