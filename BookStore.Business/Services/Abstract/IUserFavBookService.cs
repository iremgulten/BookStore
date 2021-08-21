using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.Business.Services.Abstract
{
    public interface IUserFavBookService
    {
        IList<UserFavBookRequest> GetAll();
        UserFavBook GetById(int id);
        IList<GetByUserIdDTO> GetByUserId(UserIdDTO userId);
        IList<GetByUserNameDTO> GetByUserName(UserNameDTO userId);
        void Delete(UserFavBook request);
    }
}
