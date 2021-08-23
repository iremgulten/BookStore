﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.UserFavBookDTO;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var userFav = service.GetById(id);
            if (userFav != null)
                return Ok(userFav);
            return NotFound();
        }
        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(UserIdDTO userId)
        {
            var userFav = service.GetByUserId(userId);
            if (userFav != null)
                return Ok(userFav);

            return NotFound();
        }
        [HttpGet("GetByUserName")]
        public IActionResult GetByUserName(UserNameDTO userName)
        {
            var userFav = service.GetByUserName(userName);
            if (userFav != null)
                return Ok(userFav);

            return NotFound();
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var isExisting = service.GetById(id);
            if (isExisting == null)
                return NotFound();
            service.Delete(isExisting);
            return Ok();
        }
        [HttpPost("AddNewUserFav")]
        public IActionResult Add(AddNewFavBook request)
        {
            service.Add(request);
            return Ok();
        }
    }
}