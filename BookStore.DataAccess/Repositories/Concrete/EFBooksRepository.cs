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
        public BooksTable Update(BooksTable entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }
        public IList<BooksTable> GetAll()
        {
            return dbContext.BooksTables
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre).ToList();
        }
        public BooksTable GetById(int id)
        {
            return dbContext.BooksTables
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .AsNoTracking()
                .FirstOrDefault(opt => opt.Id == id);
        }
        public IList<BooksTable> GetAllBookFlags()
        {
            return dbContext.BooksTables
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre).ToList();
        }
        
        public IList<BooksTable> GetByAuthor(int id)
        {
            return dbContext.BooksTables
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .Where(opt => opt.AuthorId == id)
                .ToList();
        }

        public IList<BooksTable>  GetByPublisher(int id)
        {
            return dbContext.BooksTables
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .Where(opt => opt.PublisherId == id)
                .ToList();
        }
        public IList<BooksTable> GetByGenre(int id)
        {
            return dbContext.BooksTables
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .Where(opt => opt.GenreId == id)
                .ToList();
        }

    }
}
