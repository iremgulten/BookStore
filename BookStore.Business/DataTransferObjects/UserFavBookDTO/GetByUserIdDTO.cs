using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects.UserFavBookDTO
{
    public class GetByUserIdDTO
    {
        public UserNameDTO User { get; set; }
        public BookNameDTO Book { get; set; }
    }
}
