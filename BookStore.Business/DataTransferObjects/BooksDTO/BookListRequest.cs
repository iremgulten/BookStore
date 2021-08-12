using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;

namespace BookStore.Business.DataTransferObjects.BooksDTO
{
    public class BookListRequest
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public AuthorNameRequest Author { get; set; }
        public PublisherNameRequest Publisher { get; set; }
        public GenreNameRequest Genre { get; set; }
        public int NumberOfPage { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImgPath { get; set; }
        public string Summary { get; set; }
    }
}
