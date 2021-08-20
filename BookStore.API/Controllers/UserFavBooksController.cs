using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavBooksController : ControllerBase
    {
        private IUserFavBookService service;
        public UserFavBooksController(IUserFavBookService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = service.GetAll();
            return Ok(result);
        }
    }
}
