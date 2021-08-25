using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects.UserFavBookDTO
{
    public class UserFavBookRequest
    {
        public UserNameDTO User { get; set; }
        public BookName Book { get; set; }
    }
}
