using System.Collections.Generic;
using AutoMapper;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
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

        public int AddBook(AddNewBookRequest request)
        {
            var newBook = mapper.Map<Book>(request);
            bookRepository.Add(newBook);
            return newBook.Id;
        }

        public void DeleteBook(BookListRequest request)
        {
            var temp = mapper.Map<DeleteBookRequest>(request);
            var book = mapper.Map<Book>(temp);
            bookRepository.Delete(book);
        }

        public int UpdateBook(int id, EditBookRequest request)
        {
            var book = mapper.Map<Book>(request);
            book.Id = id;
            return bookRepository.Update(book).Id;
        }

        public IList<BookListRequest> GetAllBooks()
        {
            var bookList = bookRepository.GetAll();
            return mapper.Map<List<BookListRequest>>(bookList);
        }

        public BookListRequest GetBooksById(int id)
        {
            Book book = bookRepository.GetById(id);
            return mapper.Map<BookListRequest>(book);
        }

        public IList<BookFlagsRequest> GetFlagById(int id)
        {
            var bookList = bookRepository.GetById(id);
            var dtoList = mapper.Map<List<BookFlagsRequest>>(bookList);
            return dtoList;
        }

        public IList<BookFlagsRequest> GetAllBookFlags()
        {
            var bookList = bookRepository.GetAllBookFlags();
            return mapper.Map<List<BookFlagsRequest>>(bookList);
        }

        public IList<BookFlagsRequest> GetBooksByAuthor(int authorId)
        {
            var books = bookRepository.GetByAuthor(authorId);
            return mapper.Map<List<BookFlagsRequest>>(books);
        }

        public IList<BookFlagsRequest> GetBooksByAuthorName(GetBooksByAuthorName author)
        {
            var books = bookRepository.GetBooksByAuthorName(author.NameSurname);
            return mapper.Map<List<BookFlagsRequest>>(books);
        }

        public IList<BookFlagsRequest> GetBooksByGenre(int genreId)
        {
            var books = bookRepository.GetByGenre(genreId);
            return mapper.Map<List<BookFlagsRequest>>(books);
        }
        public IList<BookFlagsRequest> GetBooksByGenreName(EditGenreRequest genre)
        {
            var books = bookRepository.GetBooksByGenreName(genre.Name);
            return mapper.Map<List<BookFlagsRequest>>(books);
        }

        public IList<BookFlagsRequest> GetBooksByPublisher(int publisherId)
        {
            var books = bookRepository.GetByPublisher(publisherId);
            return mapper.Map<List<BookFlagsRequest>>(books);
        }
        public IList<BookFlagsRequest> GetBooksByPublisherName(GetBooksByPublisherName publisher)
        {
            var books = bookRepository.GetBooksByPublisherName(publisher.Name);
            return mapper.Map<List<BookFlagsRequest>>(books);
        }
    }
}
