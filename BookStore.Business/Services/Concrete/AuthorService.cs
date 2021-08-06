using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;

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
            var newAuthor = mapper.Map<AuthorsTable>(request);
            authorRepository.Add(newAuthor);
            return newAuthor.Id;
        }

        public void DeleteAuthor(AuthorsListResponse request)
        {
            var author = mapper.Map<AuthorsTable>(request);
            authorRepository.Delete(author);
        }

        public IList<AuthorsListResponse> GetAllAuthors()
        {
            var dtoList = authorRepository.GetAll().ToList();
            return mapper.Map<List<AuthorsListResponse>>(dtoList);
        }

        public AuthorsListResponse GetAuthorById(int id)
        {
            AuthorsTable genre = authorRepository.GetById(id);
            return mapper.Map<AuthorsListResponse>(genre);
        }

        public int UpdateAuthor(EditAuthorRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
