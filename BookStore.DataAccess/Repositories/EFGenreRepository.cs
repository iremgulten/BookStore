using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories
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

        public void Delete(int id)
        {
            dbContext.GenresTables.Remove(GetById(id));
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

        public IList<GenresTable> GetWithCriteria(Expression<Func<GenresTable, bool>> criteria)
        {
            return dbContext.GenresTables.Where(criteria).ToList();
        }

        public GenresTable Update(GenresTable genre)
        {
            dbContext.Entry(genre).State = EntityState.Modified;
            dbContext.SaveChanges();
            return genre;
        }
    }
}
