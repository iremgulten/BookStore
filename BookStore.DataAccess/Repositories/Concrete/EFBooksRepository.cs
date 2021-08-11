using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
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
        public Book Add(Book entity)
        {
            dbContext.Books.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }
        public void Delete(Book entity)
        {
            dbContext.Books.Remove(entity);
            dbContext.SaveChanges();
        }
        public Book Update(Book entity)
        {
            dbContext.Books.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }
        public IList<Book> GetAll()
        {
            return dbContext.Books
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre).ToList();
        }
        public Book GetById(int id)
        {
            return dbContext.Books
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .AsNoTracking()
                .FirstOrDefault(opt => opt.Id == id);
        }
        public IList<Book> GetAllBookFlags()
        {
            return dbContext.Books
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre).ToList();
        }
        
        public IList<Book> GetByAuthor(int id)
        {
            return dbContext.Books
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .Where(opt => opt.AuthorId == id)
                .ToList();
        }
        public IList<Book> GetBooksByAuthorName(string author)
        {
            return dbContext.Books
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .Where(opt => opt.Author.NameSurname.ToLower() == author.ToLower())
                .ToList();
        }

        public IList<Book>  GetByPublisher(int id)
        {
            return dbContext.Books
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .Where(opt => opt.PublisherId == id)
                .ToList();
        }
        public IList<Book> GetBooksByPublisherName(string publisher)
        {
            return dbContext.Books
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .Where(opt => opt.Publisher.Name.ToLower() == publisher.ToLower())
                .ToList();
        }
        public IList<Book> GetByGenre(int id)
        {
            return dbContext.Books
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .Where(opt => opt.GenreId == id)
                .ToList();
        }
        public IList<Book> GetBooksByGenreName(string genre)
        {
            return dbContext.Books
                .Include(opt => opt.Author)
                .Include(opt => opt.Publisher)
                .Include(opt => opt.Genre)
                .Where(opt => opt.Genre.Name.ToLower() == genre.ToLower())
                .ToList();
        }
    }
}
