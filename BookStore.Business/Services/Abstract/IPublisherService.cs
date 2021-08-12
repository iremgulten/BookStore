using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.PublishersDTO;

namespace BookStore.Business.Services.Abstract
{
    public interface IPublisherService
    {
        IList<PublisherListRequest> GetAllPublishers();
        int AddPublisher(AddNewPublisherRequest request);
        PublisherListRequest GetPublisherById(int id);
        int UpdatePublisher(int id, EditPublisherRequest request);
        void DeletePublisher(PublisherListRequest request);
    }
}
