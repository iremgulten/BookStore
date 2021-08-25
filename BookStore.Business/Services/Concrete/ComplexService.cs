using AutoMapper;
using BookStore.Business.DataTransferObjects;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.Business.Services.Concrete
{
    public class ComplexService : IComplexService
    {
        //private IAuthorRepository authorRepository;
        //private IPublisherRepository publisherRepository;
        //private IGenreRepository genreRepository;
        //private IBooksRepository booksRepository;
        //private IMapper mapper;
        //public ComplexService(IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IGenreRepository genreRepository, IBooksRepository booksRepository, IMapper mapper)
        //{
        //    this.authorRepository = authorRepository;
        //    this.publisherRepository = publisherRepository;
        //    this.genreRepository = genreRepository;
        //    this.booksRepository = booksRepository;
        //    this.mapper = mapper;
        //}


        private IComplexRepository repository;
        private IMapper mapper;
        public ComplexService(IComplexRepository complexRepository, IMapper mapper)
        {
            repository = complexRepository;
            this.mapper = mapper;
        }
        public void AddComplexData(ComplexAddDTO request)
        {
            var newAuthor = mapper.Map<Author>(request);
            var newPublisher = mapper.Map<Publisher>(request);
            var newGenre = mapper.Map<Genre>(request);
            var newBook = mapper.Map<Book>(request);

            repository.Add(newAuthor, newPublisher, newGenre, newBook);
        }
    }
}
