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
        public List<AuthorsListRequest> list;
        public AuthorsListRequest request;


        public AuthorsControllerTest()
        {
            request = new AuthorsListRequest { Id = 1, NameSurname = "Stephen King", Biography = "******" };
            list = new List<AuthorsListRequest>();

            list.Add(new AuthorsListRequest { Id = 1, NameSurname = "Stephen King", Biography = "******" });
            list.Add(new AuthorsListRequest { Id = 2, NameSurname = "Dostoyevski", Biography = "******" });
            list.Add(new AuthorsListRequest { Id = 3, NameSurname = "Jack London", Biography = "******" });
            list.Add(new AuthorsListRequest { Id = 4, NameSurname = "Jane Austen", Biography = "******" });
            list.Add(new AuthorsListRequest { Id = 5, NameSurname = "Jose Saramago", Biography = "******" });
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
        public void GetAllAuthors_ShouldReturnOk()
        {
            mockService = new Mock<IAuthorService>();
            mockService.Setup(o => o.GetAllAuthors()).Returns(list);

            controller = new AuthorsController(mockService.Object);
            var result = controller.GetAllAuthors();

            Assert.IsType<OkObjectResult>(result);
        }

    }
}
