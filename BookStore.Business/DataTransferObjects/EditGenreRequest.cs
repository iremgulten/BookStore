using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Business.DataTransferObjects
{
    public class EditGenreRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Type field cannot be empty")]
        public string Name { get; set; }
    }
}