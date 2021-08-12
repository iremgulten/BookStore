using System.Collections.Generic;
using System.Linq;
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
        public void AddPublisher(AddNewPublisherRequest request)
        {
            var newPublisher = mapper.Map<Publisher>(request);
            publisherRepository.Add(newPublisher);
        }

        public void DeletePublisher(PublisherListRequest publisherListRequest)
        {
            var publisher = mapper.Map<Publisher>(publisherListRequest);
            publisherRepository.Delete(publisher);
        }

        public IList<PublisherListRequest> GetAllPublishers()
        {
            var dtoList = publisherRepository.GetAll().ToList();
            return mapper.Map<IList<PublisherListRequest>>(dtoList);
        }

        public PublisherListRequest GetPublisherById(int id)
        {
            Publisher publisher = publisherRepository.GetById(id);
            return mapper.Map<PublisherListRequest>(publisher);
        }

        public void UpdatePublisher(EditPublisherRequest request)
        {
            var publisher = mapper.Map<Publisher>(request);
            publisherRepository.Update(publisher);
        }
    }
}
