using BookStore.Business.DataTransferObjects;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexController : ControllerBase
    {
        private IComplexService service;
        public ComplexController(IComplexService complexService)
        {
            service = complexService;
        }
        [HttpPost("AddNewComplexDTO")]
        public IActionResult AddBook(ComplexAddDTO request)
        {
            service.AddComplexData(request);
            return Ok();
        }
    }
}
