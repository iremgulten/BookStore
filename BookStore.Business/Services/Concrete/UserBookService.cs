using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.DataAccess.Repositories.Concrete;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.Business.Services.Concrete
{
    public class UserBookService : IUserBookService
    {
        private IUserBookRepository repository;
        private IMapper mapper;
        public UserBookService(IUserBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IList<UserFavBookRequest> GetAll()
        {
            var dtoList = repository.GetAll(IncludeTypes.User | IncludeTypes.Book);
            return mapper.Map<IList<UserFavBookRequest>>(dtoList);
        }
        public UserBook GetById(int id)
        {
            var dto = repository.GetById(id, IncludeTypes.User | IncludeTypes.Book);
            return dto;
        }
        public IList<GetByUserIdDTO> GetByUserId(UserIdDTO userId)
        {
            var dtoList = repository.GetByUserId(userId.UserId, IncludeTypes.User | IncludeTypes.Book);
            return mapper.Map<IList<GetByUserIdDTO>>(dtoList);
        }

        public IList<GetByUserNameDTO> GetByUserName(UserNameDTO userId)
        {
            var dtoList = repository.GetByUserName(userId.UserName, IncludeTypes.User | IncludeTypes.Book);
            return mapper.Map<IList<GetByUserNameDTO>>(dtoList);
        }
        public void Delete(UserBook request)
        {
            repository.Delete(request);
        }

        public void Add(AddNewFavBook request)
        {
            var newUserFav = mapper.Map<UserBook>(request);
            repository.Add(newUserFav);
        }
    }
}
