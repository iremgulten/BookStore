using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects;

namespace BookStore.Business.Services.Abstract
{
    public interface IGenreService
    {
        IList<GenreListResponse> GetAllGenres();
        int AddGenre(AddNewGenreRequest request);
        GenreListResponse GetGenresById(int id);
        int UpdateGenre(EditGenreRequest request);
        void DeleteGenre(GenreListResponse request);
    }
}
