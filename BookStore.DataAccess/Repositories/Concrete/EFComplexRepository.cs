using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EFComplexRepository : IComplexRepository
    {
        private BookStoreContext dbContext;
        public EFComplexRepository(BookStoreContext context)
        {
            dbContext = context;
        }
        public void Add(Author author, Publisher publisher, Genre genre, Book book)
        {
            dbContext.Authors.Add(author);
            dbContext.Publishers.Add(publisher);
            dbContext.Genres.Add(genre);
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }
    }
}
