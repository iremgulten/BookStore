using System.Collections.Generic;
using BookStore.Business.DataTransferObjects.GenresDTO;

namespace BookStore.Business.Services.Abstract
{
    public interface IGenreService
    {
        IList<GenreListRequest> GetAllGenres();
        int AddGenre(AddNewGenreRequest request);
        GenreListRequest GetGenresById(int id);
        int UpdateGenre(int id,EditGenreRequest request);
        void DeleteGenre(GenreListRequest request);
    }
}
