using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entities;

namespace BookStore.Business.Services.Abstract
{
    public interface IUserService
    {
        UsersTable GetUser(string email, string password);
    }
}
