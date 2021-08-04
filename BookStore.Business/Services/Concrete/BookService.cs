using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Business.DataTransferObjects;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Models;

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
            throw new NotImplementedException();
        }

        public IList<BooksFlag> GetAllBooksFlag()
        {
            var dtoList = bookRepository.GetAll().ToList();
            return mapper.Map<List<BooksFlag>>(dtoList);
        }

        public BooksListResponse GetBooksById(int id)
        {
            BooksTable book = bookRepository.GetById(id);
            return mapper.Map<BooksListResponse>(book);
        }

        public int UpdateBook(EditBookRequest request)
        {
            var book = mapper.Map<BooksTable>(request);
            int id = bookRepository.Update(book).Id;
            return id;
        }
    }
}
