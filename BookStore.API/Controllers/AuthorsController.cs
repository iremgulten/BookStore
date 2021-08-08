using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService service;
        public AuthorsController(IAuthorService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllAuthors")]
        public IActionResult GetAllAuthors()
        {
            var result = service.GetAllAuthors();
            return Ok(result);
        }

        [HttpPost("GetAuthorById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var author = service.GetAuthorById(id);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound();
        }
        [HttpPost("AddNewAuthor")]
        public IActionResult AddAuthor(AddNewAuthorRequest request)
        {
            service.AddAuthor(request);
            return Ok();

        }

        [HttpDelete("DeleteAuthor/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var isExisting = service.GetAuthorById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            service.DeleteAuthor(isExisting);
            return Ok();
        }

        [HttpPut("UpdateAuthor/{id}")]
        public IActionResult UpdateGenre(int id, EditAuthorRequest request)
        {
            var isExisting = service.GetAuthorById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                service.UpdateAuthor(id, request);
                return Ok();

            }
            return BadRequest();
        }

    }
}
