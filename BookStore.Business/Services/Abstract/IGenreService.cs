using System.Collections.Generic;
using BookStore.Business.DataTransferObjects.GenresDTO;

namespace BookStore.Business.Services.Abstract
{
    public interface IGenreService
    {
        IList<GenreListRequest> GetAllGenres();
        void AddGenre(AddNewGenreRequest request);
        GenreListRequest GetGenresById(int id);
        void UpdateGenre(EditGenreRequest request);
        void DeleteGenre(GenreListRequest request);
    }
}
