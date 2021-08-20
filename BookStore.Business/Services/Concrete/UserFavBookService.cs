using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.DataAccess.Repositories.Concrete;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.Business.Services.Concrete
{
    public class UserFavBookService : IUserFavBookService
    {
        private IUserFavBookRepository repository;
        private IMapper mapper;
        public UserFavBookService(IUserFavBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IList<UserFavBookRequest> GetAll()
        {
            var dtoList = repository.GetAll(IncludeTypes.AspNetUser | IncludeTypes.Book);
            return mapper.Map<IList<UserFavBookRequest>>(dtoList);
        }

    }
}
