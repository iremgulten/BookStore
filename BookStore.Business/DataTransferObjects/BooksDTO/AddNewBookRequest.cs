using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;

namespace BookStore.Business.DataTransferObjects.BooksDTO
{
    public class AddNewBookRequest
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public GetBooksByAuthorName Author { get; set; }
        public GetBooksByPublisherName Publisher { get; set; }
        public AddNewGenreRequest Genre { get; set; }
        public int NumberOfPage { get; set; }
        public decimal Price { get; set; }
        public string Summary { get; set; }
        public string ImgPath { get; set; }
        public int Stock { get; set; }
    }
}
