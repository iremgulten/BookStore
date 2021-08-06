using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;

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
            var newBook = mapper.Map<BooksTable>(request);
            bookRepository.Add(newBook);
            return newBook.Id;
        }

        public void DeleteBook(BooksListResponse request)
        {
            var temp = mapper.Map<DeleteBookRequest>(request);
            var book = mapper.Map<BooksTable>(temp);
            bookRepository.Delete(book);
        }

        public int UpdateBook(EditBookRequest request)
        {
            var book = mapper.Map<BooksTable>(request);
            return bookRepository.Update(book).Id;
        }

        public IList<BooksListResponse> GetAllBooks()
        {
            var bookList = bookRepository.GetAll();
            return mapper.Map<List<BooksListResponse>>(bookList);
        }

        public BooksListResponse GetBooksById(int id)
        {
            BooksTable book = bookRepository.GetById(id);
            return mapper.Map<BooksListResponse>(book);
        }

        public IList<BookFlagsResponse> GetFlagById(int id)
        {
            var bookList = bookRepository.GetById(id);
            var dtoList = mapper.Map<List<BookFlagsResponse>>(bookList);
            return dtoList;
        }

        public IList<BookFlagsResponse> GetAllBookFlags()
        {
            var bookList = bookRepository.GetAllBookFlags();
            return mapper.Map<List<BookFlagsResponse>>(bookList);
        }

        public IList<BookFlagsResponse> GetBooksByAuthor(int authorId)
        {
            var books = bookRepository.GetByAuthor(authorId);
            return mapper.Map<List<BookFlagsResponse>>(books);
        }

        public IList<BookFlagsResponse> GetBooksByAuthorName(GetBooksByAuthorName author)
        {
            var books = bookRepository.GetBooksByAuthorName(author.NameSurname);
            return mapper.Map<List<BookFlagsResponse>>(books);
        }

        public IList<BookFlagsResponse> GetBooksByGenre(int genreId)
        {
            var books = bookRepository.GetByGenre(genreId);
            return mapper.Map<List<BookFlagsResponse>>(books);
        }
        public IList<BookFlagsResponse> GetBooksByGenreName(EditGenreRequest genre)
        {
            var books = bookRepository.GetBooksByGenreName(genre.Name);
            return mapper.Map<List<BookFlagsResponse>>(books);
        }

        public IList<BookFlagsResponse> GetBooksByPublisher(int publisherId)
        {
            var books = bookRepository.GetByPublisher(publisherId);
            return mapper.Map<List<BookFlagsResponse>>(books);
        }
        public IList<BookFlagsResponse> GetBooksByPublisherName(GetBooksByPublisherName publisher)
        {
            var books = bookRepository.GetBooksByPublisherName(publisher.Name);
            return mapper.Map<List<BookFlagsResponse>>(books);
        }
    }
}
