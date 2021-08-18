using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.UserIdentityDTO;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetAuthorById/{id:int}")]
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
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddAuthor(AddNewAuthorRequest request)
        {
            service.AddAuthor(request);
            return Ok();
        }

        [HttpDelete("DeleteAuthor/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
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

        [HttpPut("UpdateAuthor")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult UpdateGenre(EditAuthorRequest request)
        {
            var isExisting = service.GetAuthorById(request.Id);
            if (isExisting == null)
                return NotFound();

            service.UpdateAuthor(request);
            return Ok();
        }
    }
}
