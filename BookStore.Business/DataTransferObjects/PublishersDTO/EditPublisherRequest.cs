using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects.PublishersDTO
{
    public class EditPublisherRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
