using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using BookStore.Business.DataTransferObjects.UserIdentityDTO;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookController : ControllerBase
    {
        private IUserBookService service;
        public UserBookController(IUserBookService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = service.GetAll();
            return Ok(result);
        }

        [HttpPost("GetByUserId")]
        public IActionResult GetByUserId(UserIdDTO userId)
        {
            var userFav = service.GetByUserId(userId);
            if (userFav != null)
                return Ok(userFav);

            return NotFound();
        }
        [HttpPost("GetByUserName")]
        public IActionResult GetByUserName(UserNameDTO userName)
        {
            var userFav = service.GetByUserName(userName);
            if (userFav != null)
                return Ok(userFav);

            return NotFound();
        }
        [HttpDelete("Delete")]
        //[Authorize(Roles = UserRoles.Admin)]
        public IActionResult Delete(DeleteUserFav userFav)
        {
            service.Delete(userFav);
            return Ok();
        }
        [HttpPost("AddNewUserFav")]
        //[Authorize(Roles = UserRoles.Admin)]
        public IActionResult Add(AddNewFavBook request)
        {
            service.Add(request);
            return Ok();
        }
    }
}
