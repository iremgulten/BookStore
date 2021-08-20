using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects.UserFavBookDTO
{
    public class AddNewFavBook
    {
        public UserNameDTO userName { get; set; }
        public BookNameDTO bookName { get; set; }
    }
}
