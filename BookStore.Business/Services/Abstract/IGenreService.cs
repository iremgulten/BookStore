using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.GenresDTO;

namespace BookStore.Business.Services.Abstract
{
    public interface IGenreService
    {
        Task<IList<GenreListRequest>> GetAllGenres();
        Task AddGenre(AddNewGenreRequest request);
        Task<GenreListRequest> GetGenresById(int id);
        Task UpdateGenre(EditGenreRequest request);
        Task DeleteGenre(GenreListRequest request);
    }
}
