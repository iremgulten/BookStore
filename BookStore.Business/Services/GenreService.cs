using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Business.DataTransferObjects;
using BookStore.DataAccess.Repositories;
using BookStore.Models;

namespace BookStore.Business.Services
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
        
        public int AddGenre(AddNewGenreRequest request)
        {
            var newGenre = mapper.Map<GenresTable>(request);
            genreRepository.Add(newGenre);
            return newGenre.Id;

        }

        public void DeleteGenre(GenreListResponse genre)
        {
            genreRepository.Delete(genre);
        }

        public IList<GenreListResponse> GetAllGenres()
        {
            var dtoList = genreRepository.GetAll().ToList();
            return mapper.Map<List<GenreListResponse>>(dtoList);
        }

        public GenreListResponse GetGenresById(int id)
        {
            GenresTable genre = genreRepository.GetById(id);
            return mapper.Map<GenreListResponse>(genre);
        }

        public int UpdateGenre(EditGenreRequest request)
        {
            var genre = mapper.Map<GenresTable>(request);
            int id = genreRepository.Update(genre).Id;
            return id;
        }
    }
}
