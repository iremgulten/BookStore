using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.Business.Services.Concrete
{
    public class GenreService : IGenreService
    {
        private IGenreRepository genreRepository;
        private IMapper mapper;
        public GenreService(IGenreRepository genreRepository,IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }
        
        public async Task AddGenre(AddNewGenreRequest request)
        {
            var newGenre = mapper.Map<Genre>(request);
            await genreRepository.Add(newGenre);
        }

        public async Task DeleteGenre(GenreListRequest genreListrequest)
        {
            var genre = mapper.Map<Genre>(genreListrequest);
            await genreRepository.Delete(genre);
        }

        public async Task<IList<GenreListRequest>> GetAllGenres()
        {
            var dtoList = await genreRepository.GetAll();
            return mapper.Map<IList<GenreListRequest>>(dtoList);
        }

        public async Task<GenreListRequest> GetGenresById(int id)
        {
            Genre genre = await genreRepository.GetById(id);
            return mapper.Map<GenreListRequest>(genre);
        }

        public async Task UpdateGenre(EditGenreRequest request)
        {
            var genre = mapper.Map<Genre>(request);
            await genreRepository.Update(genre);
        }
    }
}
