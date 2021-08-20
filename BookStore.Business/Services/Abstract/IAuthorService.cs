using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.AuthorsDTO;

namespace BookStore.Business.Services.Abstract
{
    public interface IAuthorService
    {
        Task<IList<AuthorsListRequest>> GetAllAuthors();
        Task AddAuthor(AddNewAuthorRequest request);
        Task<AuthorsListRequest> GetAuthorById(int id);
        Task UpdateAuthor(EditAuthorRequest request);
        Task DeleteAuthor(AuthorsListRequest request);
    }
}
