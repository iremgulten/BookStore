using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Business.DataTransferObjects.GenresDTO
{
    public class AddNewGenreRequest
    {
        public string Name { get; set; }
    }
}