using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Business.Services.Abstract;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities.BookStoreEntities;

namespace BookStore.Business.Services.Concrete
{
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository publisherRepository;
        private IMapper mapper;
        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            this.publisherRepository = publisherRepository;
            this.mapper = mapper;
        }
        public async Task AddPublisher(AddNewPublisherRequest request)
        {
            var newPublisher = mapper.Map<Publisher>(request);
            await publisherRepository.Add(newPublisher);
        }

        public async Task DeletePublisher(PublisherListRequest publisherListRequest)
        {
            var publisher = mapper.Map<Publisher>(publisherListRequest);
            await publisherRepository.Delete(publisher);
        }

        public async Task<IList<PublisherListRequest>> GetAllPublishers()
        {
            var dtoList = await publisherRepository.GetAll();
            return mapper.Map<IList<PublisherListRequest>>(dtoList);
        }

        public async Task<PublisherListRequest> GetPublisherById(int id)
        {
            Publisher publisher = await publisherRepository.GetById(id);
            return mapper.Map<PublisherListRequest>(publisher);
        }

        public async Task UpdatePublisher(EditPublisherRequest request)
        {
            var publisher = mapper.Map<Publisher>(request);
            await publisherRepository.Update(publisher);
        }
    }
}
