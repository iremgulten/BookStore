﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.Business.Services.Concrete
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository authorRepository;
        private IMapper mapper;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }
        public int AddAuthor(AddNewAuthorRequest request)
        {
            var newAuthor = mapper.Map<Author>(request);
            authorRepository.Add(newAuthor);
            return newAuthor.Id;
        }

        public void DeleteAuthor(AuthorsListRequest request)
        {
            var author = mapper.Map<Author>(request);
            authorRepository.Delete(author);
        }

        public IList<AuthorsListRequest> GetAllAuthors()
        {
            var dtoList = authorRepository.GetAll().ToList();
            return mapper.Map<List<AuthorsListRequest>>(dtoList);
        }

        public AuthorsListRequest GetAuthorById(int id)
        {
            Author genre = authorRepository.GetById(id);
            return mapper.Map<AuthorsListRequest>(genre);
        }

        public int UpdateAuthor(int id, EditAuthorRequest request)
        {
            var author = mapper.Map<Author>(request);
            author.Id = id;
            authorRepository.Update(author);
            return id;
        }
    }
}
