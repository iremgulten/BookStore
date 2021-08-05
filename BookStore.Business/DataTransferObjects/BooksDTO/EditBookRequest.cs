using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects.BooksDTO
{
    public class EditBookRequest
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public int NumberOfPage { get; set; }
        public decimal Price { get; set; }
        public string Summary { get; set; }
        public string ImgPath { get; set; }
        public int Stock { get; set; }
    }
}
