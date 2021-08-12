using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Business.DataTransferObjects.GenresDTO
{
    public class EditGenreRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}