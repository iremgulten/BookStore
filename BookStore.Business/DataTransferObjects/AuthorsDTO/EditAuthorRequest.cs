using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects.AuthorsDTO
{
    public class EditAuthorRequest
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Biography { get; set; }

    }
}
