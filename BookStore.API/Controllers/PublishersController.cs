using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Business.DataTransferObjects.UserIdentityDTO;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private IPublisherService service;
        public PublishersController(IPublisherService publisherService)
        {
            service = publisherService;
        }
        [HttpGet("GetAllPublishers")]
        public async Task<IActionResult> GetAllPublishers()
        {
            var result = await service .GetAllPublishers();
            return Ok(result);
        }

        [HttpGet("GetPublisherById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var publisherResponseList = await service.GetPublisherById(id);
            if (publisherResponseList != null)
            {
                return Ok(publisherResponseList);
            }
            return NotFound();
        }

        [HttpPost("AddNewPublisher")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddPublisher(AddNewPublisherRequest request)
        {
            await service .AddPublisher(request);
            return Ok();
        }

        [HttpPut("UpdatePublisher")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdatePublisher(EditPublisherRequest request)
        {
            var isExisting = await service.GetPublisherById(request.Id);
            if (isExisting == null)
                return NotFound();
            await service .UpdatePublisher(request);
            return Ok(); 
        }

        [HttpDelete("DeletePublisher/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var isExisting = await service.GetPublisherById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            await service .DeletePublisher(isExisting);
            return Ok();
        }
    }
}
