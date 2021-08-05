using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
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

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var result = service.GetAllBooks();
            return Ok(result);
        }

        [HttpGet("GetAllBookFlags")]
        public IActionResult GetAllBookFlags()
        {
            var result = service.GetAllBookFlags();
            return Ok(result);
        }

        [HttpGet("GetBookyId/{id:int}")]
        public IActionResult GetById(int id)
        {
            var book = service.GetBooksById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        [HttpGet("GetByAuthor/{id:int}")]
        public IActionResult GetByAuthor(int id)
        {
            var books = service.GetBooksByAuthor(id);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpGet("GetByAuthorName/{author}")]
        public IActionResult GetBooksByAuthorName(string author)
        {
            var books = service.GetBooksByAuthorName(author);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpGet("GetByPublisher/{id:int}")]
        public IActionResult GetByPublisher(int id)
        {
            var books = service.GetBooksByPublisher(id);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpGet("GetByPublisherName/{publisher}")]
        public IActionResult GetBooksByPublisherName(string publisher)
        {
            var books = service.GetBooksByPublisherName(publisher);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpGet("GetByGenre/{id:int}")]
        public IActionResult GetByGenre(int id)
        {
            var books = service.GetBooksByGenre(id);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpGet("GetByAuthorName/{genre}")]
        public IActionResult GetBooksByGenreName(string genre)
        {
            var books = service.GetBooksByGenreName(genre);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddBook(AddNewBookRequest request)
        {
            if (ModelState.IsValid)
            {
                service.AddBook(request);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, EditBookRequest request)
        {
            var isExisting = service.GetBooksById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                service.UpdateBook(request);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isExisting = service.GetBooksById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            service.DeleteBook(isExisting);
            return Ok();
        }
    }
}
