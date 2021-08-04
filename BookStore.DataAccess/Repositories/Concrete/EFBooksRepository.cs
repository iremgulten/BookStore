using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFBooksRepository : IBooksRepository
    {
        private BookStoreContext dbContext;
        public EFBooksRepository(BookStoreContext context)
        {
            dbContext = context;
        }
        public BooksTable Add(BooksTable entity)
        {
            dbContext.BooksTables.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(BooksTable entity)
        {
            dbContext.BooksTables.Remove(entity);
            dbContext.SaveChanges();

        }

        public IList<BooksTable> GetAll()
        {
            return dbContext.BooksTables.ToList();
        }

        public BooksTable GetById(int id)
        {
            return dbContext.BooksTables.AsNoTracking().FirstOrDefault(opt => opt.Id == id);
        }

        public IList<BooksTable> GetWithCriteria(Func<BooksTable, bool> criteria)
        {
            return dbContext.BooksTables.Where(criteria).ToList();
        }

        public BooksTable Update(BooksTable entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }
    }
}
