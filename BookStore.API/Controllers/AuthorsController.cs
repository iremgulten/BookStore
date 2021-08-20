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
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await service.GetAllAuthors();
            return Ok(result);
        }

        [HttpGet("GetAuthorById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await service.GetAuthorById(id);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound();
        }
        [HttpPost("AddNewAuthor")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddAuthor(AddNewAuthorRequest request)
        {
            await service .AddAuthor(request);
            return Ok();
        }

        [HttpDelete("DeleteAuthor/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var isExisting = await service .GetAuthorById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            await service.DeleteAuthor(isExisting);
            return Ok();
        }

        [HttpPut("UpdateAuthor")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateGenre(EditAuthorRequest request)
        {
            var isExisting = await service.GetAuthorById(request.Id);
            if (isExisting == null)
                return NotFound();

            await service.UpdateAuthor(request);
            return Ok();
        }
    }
}
