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
        UserFavBook GetById(int id, IncludeTypes type);
        IList<UserFavBook> GetByUserId(string id, IncludeTypes type);
        IList<UserFavBook> GetByUserName(string username, IncludeTypes type);
        UserFavBook Add(UserFavBook entity);
        UserFavBook Update(UserFavBook entity);
        UserFavBook Delete(UserFavBook entity);

    }
}
