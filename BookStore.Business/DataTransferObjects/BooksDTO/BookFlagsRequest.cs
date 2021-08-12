using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;

namespace BookStore.Business.DataTransferObjects.BooksDTO
{
    public class BookFlagsRequest
    {
        public string Title { get; set; }
        public GetBooksByAuthorName Author { get; set; }
        public GetBooksByPublisherName Publisher { get; set; }
        public decimal Price { get; set; }
        public string ImgPath { get; set; }
    }
}
