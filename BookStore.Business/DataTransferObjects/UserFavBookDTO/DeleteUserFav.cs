using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects.UserFavBookDTO
{
    public class DeleteUserFav
    {
        public UserNameDTO UserName { get; set; }
        public int BookId { get; set; }
    }
}
