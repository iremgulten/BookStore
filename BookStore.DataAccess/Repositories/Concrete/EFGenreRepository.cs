using System.Collections.Generic;
using System.Linq;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFGenreRepository : IGenreRepository
    {
        private BookStoreContext dbContext;

        public EFGenreRepository(BookStoreContext context)
        {
            dbContext = context;
        }

        public Genre Add(Genre entity)
        {
            dbContext.Genres.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(Genre entity)
        {
            dbContext.Genres.Remove(entity);
            dbContext.SaveChanges();
        }
        public IList<Genre> GetAll()
        {
            return dbContext.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return dbContext.Genres.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Genre Update(Genre entity)
        {
            dbContext.Genres.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
