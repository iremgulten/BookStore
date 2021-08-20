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
        Task<IList<PublisherListRequest>> GetAllPublishers();
        Task AddPublisher(AddNewPublisherRequest request);
        Task<PublisherListRequest> GetPublisherById(int id);
        Task UpdatePublisher(EditPublisherRequest request);
        Task DeletePublisher(PublisherListRequest request);
    }
}
