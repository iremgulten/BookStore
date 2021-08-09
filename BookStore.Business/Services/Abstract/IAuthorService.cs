﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.AuthorsDTO;

namespace BookStore.Business.Services.Abstract
{
    public interface IAuthorService
    {
        IList<AuthorsListResponse> GetAllAuthors();
        int AddAuthor(AddNewAuthorRequest request);
        AuthorsListResponse GetAuthorById(int id);
        int UpdateAuthor(int id, EditAuthorRequest request);
        void DeleteAuthor(AuthorsListResponse request);
    }
}