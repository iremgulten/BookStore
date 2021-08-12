using System.Collections.Generic;
using AutoMapper;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.DataAccess.Repositories.Concrete;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.Business.Services.Concrete
{
    public class BookService : IBooksService
    {
        private IBooksRepository bookRepository;
        private IMapper mapper;
        public BookService(IBooksRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public void AddBook(AddNewBookRequest request)
        {
            var newBook = mapper.Map<Book>(request);
            bookRepository.Add(newBook);
        }

        public void DeleteBook(BookListRequest request)
        {
            var book = mapper.Map<Book>(request);
            bookRepository.Delete(book);
        }

        public void UpdateBook(EditBookRequest request)
        {
            var book = mapper.Map<Book>(request);
            bookRepository.Update(book);
        }

        public IList<BookListRequest> GetAllBooks()
        {
            var bookList = bookRepository.GetAll(IncludeTypes.Author | IncludeTypes.Publisher | IncludeTypes.Genre);
            return mapper.Map<IList<BookListRequest>>(bookList);
        }

        public BookListRequest GetBooksById(int id)
        {
            var book = bookRepository.GetById(id, IncludeTypes.Author | IncludeTypes.Publisher | IncludeTypes.Genre);
            return mapper.Map<BookListRequest>(book);
        }

        public BookFlagsRequest GetBookFlagById(int id)
        {
            var bookList = bookRepository.GetById(id, IncludeTypes.Author | IncludeTypes.Publisher | IncludeTypes.Genre);
            return mapper.Map<BookFlagsRequest>(bookList);
        }

        public IList<BookFlagsRequest> GetAllBookFlags()
        {
            var bookList = bookRepository.GetAllBookFlags(IncludeTypes.Author | IncludeTypes.Publisher);
            return mapper.Map<IList<BookFlagsRequest>>(bookList);
        }

        public IList<BookFlagsRequest> GetBooksByAuthor(int authorId)
        {
            var books = bookRepository.GetByAuthor(authorId, IncludeTypes.Author | IncludeTypes.Publisher | IncludeTypes.Genre);
            return mapper.Map<IList<BookFlagsRequest>>(books);
        }

        public IList<BookFlagsRequest> GetBooksByAuthorName(GetBooksByAuthorName author)
        {
            var books = bookRepository.GetBooksByAuthorName(author.NameSurname, IncludeTypes.Author | IncludeTypes.Publisher | IncludeTypes.Genre);
            return mapper.Map<IList<BookFlagsRequest>>(books);
        }

        public IList<BookFlagsRequest> GetBooksByGenre(int genreId)
        {
            var books = bookRepository.GetByGenre(genreId, IncludeTypes.Author | IncludeTypes.Publisher | IncludeTypes.Genre);
            return mapper.Map<IList<BookFlagsRequest>>(books);
        }
        public IList<BookFlagsRequest> GetBooksByGenreName(GenreNameRequest genre)
        {
            var books = bookRepository.GetBooksByGenreName(genre.Name, IncludeTypes.Author | IncludeTypes.Publisher | IncludeTypes.Genre);
            return mapper.Map<IList<BookFlagsRequest>>(books);
        }

        public IList<BookFlagsRequest> GetBooksByPublisher(int publisherId)
        {
            var books = bookRepository.GetByPublisher(publisherId, IncludeTypes.Author | IncludeTypes.Publisher | IncludeTypes.Genre);
            return mapper.Map<IList<BookFlagsRequest>>(books);
        }
        public IList<BookFlagsRequest> GetBooksByPublisherName(GetBooksByPublisherName publisher)
        {
            var books = bookRepository.GetBooksByPublisherName(publisher.Name, IncludeTypes.Author | IncludeTypes.Publisher | IncludeTypes.Genre);
            return mapper.Map<IList<BookFlagsRequest>>(books);
        }
    }
}
