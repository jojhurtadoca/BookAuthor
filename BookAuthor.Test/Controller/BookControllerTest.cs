using BookAuthor.Controllers;
using BookAuthor.Models.Dto;
using BookAuthor.Service.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Text.Json;

namespace BookAuthor.Test.Controller
{
    [TestFixture]
    public class BookControllerTest {

        private BookController bookController;

        [Test]
        public async Task CreateBookTestOK()
        {
            var mock = new Mock<ILogger<BookController>>();
            ILogger<BookController> logger = mock.Object;

            var mockService = new Mock<IBookService>();

            GenderDTO genderDTO = new GenderDTO();
            genderDTO.Id = 1;
            genderDTO.Name = "Gender test 1";

            AuthorDTO author = new AuthorDTO();
            author.Id = 1;
            author.Name = "Author name 1";

            CreateBookDTO dto = new CreateBookDTO();
            dto.Author = 1;
            dto.Title = "Test title";
            dto.Description = "Test description";
            dto.Price = 1000;
            dto.Gender = 1;

            BookDTO bookDTO = new BookDTO();
            bookDTO.Id = 1;
            bookDTO.Title = "Test title";
            bookDTO.Description = "Test description";
            bookDTO.Price = 1000;
            bookDTO.Gender = genderDTO;
            bookDTO.Author = author;

            mockService.Setup(p => p.CreateBook(dto)).Returns(Task.FromResult(bookDTO));

            bookController = new BookController(mock.Object, mockService.Object);

            var result = await bookController.CreateBook(dto);

            var okResult = result as JsonResult;
            var jsonString = JsonSerializer.Serialize(okResult?.Value);
            var resultJson = JsonSerializer.Deserialize<JsonElement>(jsonString);

            Assert.IsNotNull(resultJson);
            Assert.Equals(201, resultJson.GetProperty("StatusCode").GetInt64());
            Assert.Equals("Book created successfully", resultJson.GetProperty("Message").GetString());
            Assert.Equals(bookDTO, resultJson.GetProperty("Content"));
        }

        [Test]
        public async Task CreateBookTestWithAuthorNotFound()
        {
           
        }

        [Test]
        public void GetTheMostExpensiveBookTest()
        {

        }
    }
}
