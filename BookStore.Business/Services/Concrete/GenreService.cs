using System.Collections.Generic;
using System.Linq;
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
        
        public void AddGenre(AddNewGenreRequest request)
        {
            var newGenre = mapper.Map<Genre>(request);
            genreRepository.Add(newGenre);
        }

        public void DeleteGenre(GenreListRequest genreListrequest)
        {
            var genre = mapper.Map<Genre>(genreListrequest);
            genreRepository.Delete(genre);
        }

        public IList<GenreListRequest> GetAllGenres()
        {
            var dtoList = genreRepository.GetAll().ToList();
            return mapper.Map<IList<GenreListRequest>>(dtoList);
        }

        public GenreListRequest GetGenresById(int id)
        {
            Genre genre = genreRepository.GetById(id);
            return mapper.Map<GenreListRequest>(genre);
        }

        public void UpdateGenre(EditGenreRequest request)
        {
            var genre = mapper.Map<Genre>(request);
            genreRepository.Update(genre);
        }
    }
}
