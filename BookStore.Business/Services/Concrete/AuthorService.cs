using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task AddAuthor(AddNewAuthorRequest request)
        {
            var newAuthor = mapper.Map<Author>(request);
            await authorRepository.Add(newAuthor);
        }

        public async Task DeleteAuthor(AuthorsListRequest request)
        {
            var author = mapper.Map<Author>(request);
            await authorRepository.Delete(author);
        }

        public async Task<IList<AuthorsListRequest>> GetAllAuthors()
        {
            var dtoList = await authorRepository.GetAll();
            return mapper.Map<IList<AuthorsListRequest>>(dtoList);
        }

        public async Task<AuthorsListRequest> GetAuthorById(int id)
        {
            var author = await authorRepository.GetById(id);
            return mapper.Map<AuthorsListRequest>(author);
        }

        public async Task UpdateAuthor(EditAuthorRequest request)
        {
            var author = mapper.Map<Author>(request);
            await authorRepository.Update(author);
        }
    }
}
