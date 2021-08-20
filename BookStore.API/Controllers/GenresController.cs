using Microsoft.AspNetCore.Mvc;
using BookStore.Business.Services.Abstract;
using BookStore.Business.DataTransferObjects.GenresDTO;
using Microsoft.AspNetCore.Authorization;
using BookStore.Business.DataTransferObjects.UserIdentityDTO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get()
        {
            var result = await service.GetAllGenres();
            return Ok(result);
        }

        [HttpGet("GetGenreById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genreResponseList = await service.GetGenresById(id);
            if (genreResponseList != null)
            {
                return Ok(genreResponseList);
            }
            return NotFound();
        }

        [HttpPost("AddNewGenre")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddGenre(AddNewGenreRequest request)
        {
            await service.AddGenre(request);
            return Ok();
        }

        [HttpPut("UpdateGenre")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateGenre(EditGenreRequest request)
        {
            var isExisting = await service.GetGenresById(request.Id);
            if(isExisting == null)
                return NotFound();

            await service .UpdateGenre(request);
            return Ok();

        }
        [HttpDelete("DeleteGenre/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var isExisting = await service.GetGenresById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            await service .DeleteGenre(isExisting);
            return Ok();
        }
    }
}
