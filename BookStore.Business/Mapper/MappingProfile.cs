using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Business.DataTransferObjects;
using BookStore.Models;

namespace BookStore.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GenresTable, GenreListResponse>().ReverseMap();
            CreateMap<GenresTable, AddNewGenreRequest>().ReverseMap();
            CreateMap<GenresTable, EditGenreRequest>().ReverseMap();
        }
    }
}
