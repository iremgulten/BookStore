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
        IList<AuthorsListRequest> GetAllAuthors();
        void AddAuthor(AddNewAuthorRequest request);
        AuthorsListRequest GetAuthorById(int id);
        void UpdateAuthor(EditAuthorRequest request);
        void DeleteAuthor(AuthorsListRequest request);
    }
}
