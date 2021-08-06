using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects.AuthorsDTO
{
    public class DeleteAuthorRequest
    {
        public string NameSurname { get; set; }
        public string Biography { get; set; }

    }
}
