using System.Collections.Generic;
using System.Linq;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
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

        public GenresTable Add(GenresTable entity)
        {
            dbContext.GenresTables.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(GenresTable entity)
        {
            dbContext.GenresTables.Remove(entity);
            dbContext.SaveChanges();
        }
        public IList<GenresTable> GetAll()
        {
            return dbContext.GenresTables.ToList();
        }

        public GenresTable GetById(int id)
        {
            return dbContext.GenresTables.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public GenresTable Update(GenresTable entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }
    }
}
