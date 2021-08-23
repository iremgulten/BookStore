﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Concrete;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IUserBookRepository
    {
        IList<UserBook> GetAll(IncludeTypes type);
        UserBook GetById(int id, IncludeTypes type);
        IList<UserBook> GetByUserId(string id, IncludeTypes type);
        IList<UserBook> GetByUserName(string username, IncludeTypes type);
        UserBook Add(UserBook entity);
        UserBook Delete(UserBook entity);
    }
}
