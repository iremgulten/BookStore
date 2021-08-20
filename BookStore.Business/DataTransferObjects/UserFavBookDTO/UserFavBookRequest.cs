using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects.UserFavBookDTO
{
    public class UserFavBookRequest
    {
        public string AspNetUserId { get; set; }
        public UserNameDTO AspNetUser { get; set; }
        public int BookId { get; set; }
        public BookNameDTO Book { get; set; }
    }
}
