using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Business.DataTransferObjects.GenresDTO
{
    public class AddNewGenreRequest
    {
        [Required(ErrorMessage ="Type field cannot be empty")]
        public string Name { get; set; }
    }
}