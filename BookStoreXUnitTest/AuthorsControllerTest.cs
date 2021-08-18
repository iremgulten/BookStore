using System.Collections.Generic;
using System.Web.Http.Results;
using BookStore.API.Controllers;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BookStoreXUnitTest
{
    public class AuthorsControllerTest
    {
        private Mock<IAuthorService> mockService;
        private AuthorsController controller;
        public AuthorsListRequest request = new AuthorsListRequest { Id = 1, NameSurname = "Stephen King", Biography = "******" };
        public List<AuthorsListRequest> list = new List<AuthorsListRequest>();
        public AuthorsControllerTest()
        {
            list.Add(request);
        }
        [Fact]
        public void GetById_ShouldReturnOkResult()
        {

            mockService = new Mock<IAuthorService>();
            mockService.Setup(o => o.GetAuthorById(1)).Returns(request);

            controller = new AuthorsController(mockService.Object);
            var result = controller.GetById(1);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetById_ShouldReturnNotFoundResult()
        {
            mockService = new Mock<IAuthorService>();
            mockService.Setup(o => o.GetAuthorById(1)).Returns(request);
            
            controller = new AuthorsController(mockService.Object);
            var result = controller.GetById(2);

            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }
        [Fact]
        public void GetAllAuthors_ShouldAuthorList()
        {
            mockService = new Mock<IAuthorService>();
            mockService.Setup(o => o.GetAllAuthors()).Returns(list);

            controller = new AuthorsController(mockService.Object);
            var result = controller.GetAllAuthors();

            Assert.IsType<OkObjectResult>(result);
        }

    }
}
