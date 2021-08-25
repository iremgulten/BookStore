using System.Collections.Generic;
using System.Linq;
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
        private IBooksRepository booksRepository;
        private IMapper mapper;
        public UserBookService(IUserBookRepository repository,IBooksRepository booksRepository, IMapper mapper)
        {
            this.booksRepository = booksRepository;
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

        public IList<GetByUserNameDTO> GetByUserName(UserNameDTO userName)
        {
            var dtoList = repository.GetByUserName(userName.UserName, IncludeTypes.User | IncludeTypes.Book);
            return mapper.Map<IList<GetByUserNameDTO>>(dtoList);
        }
        public void Delete(DeleteUserFav userFav)
        {
            var userFavDto = GetByUserName(userFav.UserName).FirstOrDefault(x => x.Book.Title.ToLower().Contains(userFav.Title.Title.ToLower()));
            repository.Delete(userFavDto.Id);
        }

        public void Add(AddNewFavBook request)
        {
            var newUserFav = mapper.Map<UserBook>(request);
            newUserFav.UserId = GetByUserName(request.UserName).FirstOrDefault(x => x.User.UserName.ToLower().Contains(request.UserName.UserName.ToLower())).UserId;
           // newUserFav.BookId = BookService.GetBookByName(request.Title.Title.ToLower()).Id;
            repository.Add(newUserFav);
        }
    }
}
