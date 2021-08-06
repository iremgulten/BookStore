using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;
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

        [HttpPost("GetBookById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var book = service.GetBooksById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        [HttpPost("GetByAuthor/{id:int}")]
        public IActionResult GetByAuthor(int id)
        {
            var books = service.GetBooksByAuthor(id);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpPost("GetByAuthorName/{author}")]
        public IActionResult GetBooksByAuthorName(GetBooksByAuthorName author)
        {
            var books = service.GetBooksByAuthorName(author);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpPost("GetByPublisher/{id:int}")]
        public IActionResult GetByPublisher(int id)
        {
            var books = service.GetBooksByPublisher(id);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpPost("GetByPublisherName/{publisher}")]
        public IActionResult GetBooksByPublisherName(GetBooksByPublisherName publisher)
        {
            var books = service.GetBooksByPublisherName(publisher);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpPost("GetByGenre/{id:int}")]
        public IActionResult GetByGenre(int id)
        {
            var books = service.GetBooksByGenre(id);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
        [HttpPost("GetByGenreName")]
        public IActionResult GetBooksByGenreName(EditGenreRequest genre)
        {
            var books = service.GetBooksByGenreName(genre);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }

        [HttpPost("AddNewBook")]
        public IActionResult AddBook(AddNewBookRequest request)
        {
            service.AddBook(request);
            return Ok();

        }
        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, EditBookRequest request)
        {
            var isExisting = service.GetBooksById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            service.UpdateBook(request);
            return Ok();  
        }
        [HttpDelete("DeleteBook/{id}")]
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
