using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Concrete;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IUserFavBookRepository 
    {
        IList<UserFavBook> GetAll(IncludeTypes type);
        Task<UserFavBook> GetByUserId(string id);
        Task<IList<UserFavBook>> GetByUserName(string username);
        Task<UserFavBook> Add(UserFavBook entity);
        Task<UserFavBook> Update(UserFavBook entity);
        Task<UserFavBook> Delete(UserFavBook entity);
    }
}
