using Microsoft.AspNetCore.Mvc;
using BookStore.Business.Services.Abstract;
using BookStore.Business.DataTransferObjects.GenresDTO;
using Microsoft.AspNetCore.Authorization;
using BookStore.Business.DataTransferObjects.UserIdentityDTO;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private IGenreService service;
        public GenresController(IGenreService genreService)
        {
            service = genreService;
        }

        [HttpGet("GetAllGenres")]
        public IActionResult Get()
        {
            var result = service.GetAllGenres();
            return Ok(result);
        }

        [HttpGet("GetGenreById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var genreResponseList = service.GetGenresById(id);
            if (genreResponseList != null)
            {
                return Ok(genreResponseList);
            }
            return NotFound();
        }

        [HttpPost("AddNewGenre")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddGenre(AddNewGenreRequest request)
        {
            service.AddGenre(request);
            return Ok();
        }

        [HttpPut("UpdateGenre")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult UpdateGenre(EditGenreRequest request)
        {
            var isExisting = service.GetGenresById(request.Id);
            if(isExisting == null)
                return NotFound();

            service.UpdateGenre(request);
            return Ok();

        }
        [HttpDelete("DeleteGenre/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Delete(int id)
        {
            var isExisting = service.GetGenresById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            service.DeleteGenre(isExisting);
            return Ok();
        }
    }
}
