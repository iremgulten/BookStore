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

        public IList<GetByUserIdDTO> GetByUserId(UserIdDTO userId)
        {
            var dtoList = repository.GetByUserId(userId.AspNetUserId, IncludeTypes.AspNetUser | IncludeTypes.Book);
            return mapper.Map<IList<GetByUserIdDTO>>(dtoList);
        }

        public IList<GetByUserNameDTO> GetByUserName(UserNameDTO userId)
        {
            var dtoList = repository.GetByUserName(userId.UserName, IncludeTypes.AspNetUser | IncludeTypes.Book);
            return mapper.Map<IList<GetByUserNameDTO>>(dtoList);
        }
    }
}
