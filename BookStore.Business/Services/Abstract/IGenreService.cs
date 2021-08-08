using System.Collections.Generic;
using BookStore.Business.DataTransferObjects.GenresDTO;

namespace BookStore.Business.Services.Abstract
{
    public interface IGenreService
    {
        IList<GenreListResponse> GetAllGenres();
        int AddGenre(AddNewGenreRequest request);
        GenreListResponse GetGenresById(int id);
        int UpdateGenre(int id,EditGenreRequest request);
        void DeleteGenre(GenreListResponse request);
    }
}
