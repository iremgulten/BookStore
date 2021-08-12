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
        public IActionResult GetAllPublishers()
        {
            var result = service.GetAllPublishers();
            return Ok(result);
        }

        [HttpPost("GetPublisherById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var publisherResponseList = service.GetPublisherById(id);
            if (publisherResponseList != null)
            {
                return Ok(publisherResponseList);
            }
            return NotFound();
        }

        [HttpPost("AddNewPublisher")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddPublisher(AddNewPublisherRequest request)
        {
            if (ModelState.IsValid)
            {
                service.AddPublisher(request);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("UpdatePublisher/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult UpdatePublisher(int id, EditPublisherRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var isExisting = service.GetPublisherById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            service.UpdatePublisher(id, request);
            return Ok();
            
        }
        [HttpDelete("DeletePublisher/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult DeletePublisher(int id)
        {
            var isExisting = service.GetPublisherById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            service.DeletePublisher(isExisting);
            return Ok();
        }
    }
}
