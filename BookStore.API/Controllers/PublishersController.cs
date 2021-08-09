﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.PublishersDTO;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePublisher(int id, EditPublisherRequest request)
        {
            var isExisting = service.GetPublisherById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                service.UpdatePublisher(id, request);
                return Ok();

            }
            return BadRequest();
        }
        [HttpDelete("DeletePublisher/{id}")]
        [Authorize(Roles = "Admin")]
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