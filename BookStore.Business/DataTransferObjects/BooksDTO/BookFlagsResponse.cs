using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;

namespace BookStore.Business.DataTransferObjects.BooksDTO
{
    public class BookFlagsResponse
    {
        public string Title { get; set; }
        public AuthorNameResponse Author { get; set; }
        public PublisherNameResponse Publisher { get; set; }
        public decimal Price { get; set; }
        public string ImgPath { get; set; }
    }
}
