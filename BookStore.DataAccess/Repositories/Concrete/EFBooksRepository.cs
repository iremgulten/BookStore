using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories.Concrete
{
    [Flags]public enum IncludeTypes
    {
        Author,
        Publisher,
        Genre
    }
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
        public IList<Book> GetAll(IncludeTypes type)
        {
            IList<Book> allBooks = IncludeModels(type).ToList();
            return allBooks;
        }
        public Book GetById(int id,IncludeTypes type)
        {
            IList<Book> list = IncludeModels(type).ToList();
            return list.FirstOrDefault(opt => opt.Id == id);
        }
        public IList<Book> GetAllBookFlags(IncludeTypes type)
        {
            IList<Book> bookFlags = IncludeModels(type).ToList();
            return bookFlags;
        }
        
        public IList<Book> GetByAuthor(int id, IncludeTypes type)
        {
            IList<Book> books = IncludeModels(type).ToList();
            return books.Where(opt => opt.AuthorId == id).ToList();
        }
        public IList<Book> GetBooksByAuthorName(string author, IncludeTypes type)
        {
            IList<Book> books = IncludeModels(type).ToList();
            return books.Where(opt => opt.Author.NameSurname.ToLower().Contains(author.ToLower())).ToList();
        }

        public IList<Book>  GetByPublisher(int id, IncludeTypes type)
        {
            IList<Book> books = IncludeModels(type).ToList();
            return books.Where(opt => opt.PublisherId == id).ToList();
        }
        public IList<Book> GetBooksByPublisherName(string publisher, IncludeTypes type)
        {
            IList<Book> books = IncludeModels(type).ToList();
            return books.Where(opt => opt.Publisher.Name.ToLower().Contains(publisher.ToLower())).ToList();
        }
        public IList<Book> GetByGenre(int id, IncludeTypes type)
        {
            IList<Book> books = IncludeModels(type).ToList();
            return books.Where(opt => opt.GenreId == id).ToList();
        }
        public IList<Book> GetBooksByGenreName(string genre, IncludeTypes type)
        {
            IList<Book> books = IncludeModels(type).ToList();
            return books.Where(opt => opt.Genre.Name.ToLower().Contains(genre.ToLower())).ToList();
        }

        private List<Book> IncludeModels(IncludeTypes paramEnumType)
        {
            var bookSet = dbContext.Books;

            if (paramEnumType.HasFlag(IncludeTypes.Author))
                bookSet.Include(opt => opt.Author).Load();

            if (paramEnumType.HasFlag(IncludeTypes.Publisher))
                bookSet.Include(opt => opt.Publisher).Load();

            if (paramEnumType.HasFlag(IncludeTypes.Genre))
                bookSet.Include(opt => opt.Genre).Load();

            return bookSet.ToList();
        }
    }
}
