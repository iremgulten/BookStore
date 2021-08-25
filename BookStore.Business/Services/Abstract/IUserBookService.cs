using System.Collections.Generic;
using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.Business.Services.Abstract
{
    public interface IUserBookService
    {
        IList<UserFavBookRequest> GetAll();
        UserBook GetById(int id);
        IList<GetByUserIdDTO> GetByUserId(UserIdDTO userId);
        IList<GetByUserNameDTO> GetByUserName(UserNameDTO userId);
        void Delete(DeleteUserFav userFav);
        void Add(AddNewFavBook request);
    }
}
