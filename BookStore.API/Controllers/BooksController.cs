using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService service;
        public BooksController(IBooksService bookService)
        {
            service = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooksFlag()
        {
            var result = service.GetAllBooksFlag();
            return Ok(result);
        }
    }
}
