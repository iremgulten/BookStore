using System.Net;
using BookStore.API.Controllers;
using BookStore.Business.DataTransferObjects.AuthorsDTO;
using BookStore.Business.Services.Abstract;
using BookStore.Business.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BookStoreUnitTest.Controllers
{
    public class AuthorControllerTest
    {
        //private Mock<IAuthorService> mockService;
        //private AuthorsController controller;
        private IAuthorService _authorService;
        [Fact]
        public void GetById_ShouldReturnOkResult()
        {
            
            AuthorsListRequest request = new AuthorsListRequest { };
            var mockService = new Mock<IAuthorService>();
            
            mockService.Setup(o => o.GetAuthorById(85)).Returns(request);

            var controller = new AuthorsController(mockService.Object);
            var result = controller.GetById(85);
            var redirect = Assert.IsType<OkResult>(result);

            Assert.Equal<int>(200, (int)redirect.StatusCode);


        }
        //[Fact]
        //public void GetById_ShouldReturnBadRequestResult()
        //{
        //    var mockService = new Mock<IAuthorService>();
        //    var controller = new AuthorsController(mockService.Object);
        //    var result = controller.GetById(5);

        //    Assert.IsType<NotFoundResult>(result);
        //}

    }
}
