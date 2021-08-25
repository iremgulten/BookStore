using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.DataTransferObjects.BooksDTO;
using BookStore.Business.DataTransferObjects.GenresDTO;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Business.DataTransferObjects.UserIdentityDTO;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetBookById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var book = service.GetBooksById(id);
            if (book != null)
                return Ok(book);
            return NotFound();
        }
        [HttpGet("GetBookFlagById/{id:int}")]
        public IActionResult GetBookFlagById(int id)
        {
            var bookFlag = service.GetBookFlagById(id);
            if (bookFlag != null)
                return Ok(bookFlag);
            return NotFound();
        }
        [HttpGet("GetByAuthorId/{id:int}")]
        public IActionResult GetByAuthorId(int id)
        {
            var books = service.GetBooksByAuthor(id);
            if (books != null)
                return Ok(books);
            return NotFound();
        }
        [HttpPost("GetByAuthorName")]
        public IActionResult GetBooksByAuthorName(GetBooksByAuthorName author)
        {
            var books = service.GetBooksByAuthorName(author);
            if (books != null)
                return Ok(books);

            return NotFound();
        }
        [HttpGet("GetByPublisherId/{id:int}")]
        public IActionResult GetByPublisherId(int id)
        {
            var books = service.GetBooksByPublisher(id);
            if (books != null)
                return Ok(books);

            return NotFound();
        }
        [HttpPost("GetByPublisherName")]
        public IActionResult GetBooksByPublisherName(GetBooksByPublisherName publisher)
        {
            var books = service.GetBooksByPublisherName(publisher);
            if (books != null)
                return Ok(books);

            return NotFound();
        }
        [HttpGet("GetByGenreId/{id:int}")]
        public IActionResult GetByGenreId(int id)
        {
            var books = service.GetBooksByGenre(id);
            if (books != null)
                return Ok(books);

            return NotFound();
        }
        [HttpPost("GetByGenreName")]
        public IActionResult GetBooksByGenreName(GenreNameRequest genre)
        {
            var books = service.GetBooksByGenreName(genre);
            if (books != null)
                return Ok(books);

            return NotFound();
        }

        [HttpPost("AddNewBook")]
        //[Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddBook(AddNewBookRequest request)
        {
            service.AddBook(request);
            return Ok();
        }

        [HttpPut("UpdateBook")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult UpdateBook(EditBookRequest request)
        {
            var isExisting = service.GetBooksById(request.Id);
            if (isExisting == null)
                return NotFound();

            service.UpdateBook(request);
            return Ok();  
        }
        [HttpDelete("DeleteBook/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult DeleteBook(int id)
        {
            var isExisting = service.GetBooksById(id);
            if (isExisting == null)
                return NotFound();

            service.DeleteBook(isExisting);
            return Ok();
        }
        
    }
}
