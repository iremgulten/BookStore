using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.DataTransferObjects
{
    public class AddNewBookRequest
    {
        [Required(ErrorMessage = "Isbn field cannot be empty")]
        public string Isbn { get; set; }

        [Required(ErrorMessage = "Title field cannot be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "AuthorId field cannot be empty")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "PublisherId field cannot be empty")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "GenreId field cannot be empty")]
        public int GenreId { get; set; }
        public int NumberOfPage { get; set; }
        public decimal Price { get; set; }
        public string Summary { get; set; }
        public string ImgPath { get; set; }
        public int Stock { get; set; }
    }
}
