
using Microsoft.AspNetCore.Mvc;
using BookStore.Business.Services.Abstract;
using BookStore.Business.DataTransferObjects.GenresDTO;

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

        [HttpGet]
        public IActionResult Get()
        {
            var result = service.GetAllGenres();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var genreResponseList = service.GetGenresById(id);
            if (genreResponseList != null)
            {
                return Ok(genreResponseList);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddGenre(AddNewGenreRequest request)
        {
            if (ModelState.IsValid)
            {
                service.AddGenre(request);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]

        public IActionResult UpdateGenre(int id,EditGenreRequest request)
        {
            var isExisting = service.GetGenresById(id);
            if(isExisting == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                service.UpdateGenre(request);
                return Ok();

            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
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
