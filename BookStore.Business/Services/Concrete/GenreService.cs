﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Models;

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
        
        public int AddGenre(AddNewGenreRequest request)
        {
            var newGenre = mapper.Map<GenresTable>(request);
            genreRepository.Add(newGenre);
            return newGenre.Id;

        }

        public void DeleteGenre(GenreListResponse genreListResponse)
        {
            var genre = mapper.Map<GenresTable>(genreListResponse);
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
