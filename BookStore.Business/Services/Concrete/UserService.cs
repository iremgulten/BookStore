using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;

namespace BookStore.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public UsersTable GetUser(string email, string password)
        {
            return userRepository.GetWithCriteria(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
