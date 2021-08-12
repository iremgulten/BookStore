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
        public int AddPublisher(AddNewPublisherRequest request)
        {
            var newPublisher = mapper.Map<Publisher>(request);
            publisherRepository.Add(newPublisher);
            return newPublisher.Id;
        }

        public void DeletePublisher(PublisherListResponse publisherListResponse)
        {
            var publisher = mapper.Map<Publisher>(publisherListResponse);
            publisherRepository.Delete(publisher);
        }

        public IList<PublisherListResponse> GetAllPublishers()
        {
            var dtoList = publisherRepository.GetAll().ToList();
            return mapper.Map<List<PublisherListResponse>>(dtoList);
        }

        public PublisherListResponse GetPublisherById(int id)
        {
            Publisher publisher = publisherRepository.GetById(id);
            return mapper.Map<PublisherListResponse>(publisher);
        }

        public int UpdatePublisher(int id, EditPublisherRequest request)
        {
            var publisher = mapper.Map<Publisher>(request);
            publisher.Id = id;
            publisherRepository.Update(publisher);
            return id;
        }
    }
}
