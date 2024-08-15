using BookAuthor.Controllers;
using BookAuthor.Models.Dto;
using BookAuthor.Models.Exceptions;
using BookAuthor.Service.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.models;
using Moq;
using System;
using System.Text.Json;

namespace BookAuthor.Test.Controller
{
    [TestFixture]
    public class BookControllerTest {

        private BookController bookController;

        private CreateBookDTO CreateDTO()
        {
            CreateBookDTO dto = new CreateBookDTO();
            dto.Author = 1;
            dto.Title = "Test title";
            dto.Description = "Test description";
            dto.Price = 1000;
            dto.Gender = 1;

            return dto;
        }

        private BookDTO CreateBookDTO()
        {
            GenderDTO genderDTO = new GenderDTO();
            genderDTO.Id = 1;
            genderDTO.Name = "Gender test 1";

            AuthorDTO author = new AuthorDTO();
            author.Id = 1;
            author.Name = "Author name 1";

            BookDTO bookDTO = new BookDTO();
            bookDTO.Id = 1;
            bookDTO.Title = "Test title";
            bookDTO.Description = "Test description";
            bookDTO.Price = 1000;
            bookDTO.Gender = genderDTO;
            bookDTO.Author = author;
            return bookDTO;
        }

        [Test]
        public async Task CreateBookTestOK()
        {
            var mock = new Mock<ILogger<BookController>>();
            ILogger<BookController> logger = mock.Object;


            var mockService = new Mock<IBookService>();

            var dto = CreateDTO();
            var bookDTO = CreateBookDTO();

            mockService.Setup(p => p.CreateBook(dto)).Returns(Task.FromResult(bookDTO));

            bookController = new BookController(mock.Object, mockService.Object);

            var result = await bookController.CreateBook(dto);

            var okResult = result as JsonResult;
            var jsonString = JsonSerializer.Serialize(okResult?.Value);
            var resultJson = JsonSerializer.Deserialize<JsonElement>(jsonString);

            Assert.IsNotNull(resultJson);
            Assert.That(201 == resultJson.GetProperty("StatusCode").GetInt64());
            Assert.That("Book created successfully".Equals(resultJson.GetProperty("Message").GetString()));
        }

        [Test]
        public async Task CreateBookTestWithAuthorNotFound()
        {
            var mock = new Mock<ILogger<BookController>>();
            ILogger<BookController> logger = mock.Object;

            var mockService = new Mock<IBookService>();
            var dto = CreateDTO();

            mockService.Setup(p => p.CreateBook(dto)).Throws(new NotFoundException("Author with id '1' doesn't exist"));

            bookController = new BookController(mock.Object, mockService.Object);

            var result = await bookController.CreateBook(dto);

            var okResult = result as NotFoundObjectResult;

            Assert.IsNotNull(okResult);
            Assert.That(404 == okResult.StatusCode);
            Assert.That("Author with id '1' doesn't exist".Equals(okResult.Value));
        }

        [Test]
        public async Task GetBookByIdTestOk()
        {
            var mock = new Mock<ILogger<BookController>>();
            ILogger<BookController> logger = mock.Object;


            var mockService = new Mock<IBookService>();

            var bookDTO = CreateBookDTO();

            mockService.Setup(p => p.GetBookById(1)).Returns(Task.FromResult(bookDTO));

            bookController = new BookController(mock.Object, mockService.Object);

            var result = await bookController.GetBook(1);

            var okResult = result as JsonResult;
            var jsonString = JsonSerializer.Serialize(okResult?.Value);
            var resultJson = JsonSerializer.Deserialize<JsonElement>(jsonString);

            Assert.IsNotNull(resultJson);
            Assert.That(201 == resultJson.GetProperty("StatusCode").GetInt64());
        }

        [Test]
        public async Task GetBookByIdTestWithIdLessThan1()
        {
            var mock = new Mock<ILogger<BookController>>();
            ILogger<BookController> logger = mock.Object;
            var mockService = new Mock<IBookService>();

            bookController = new BookController(mock.Object, mockService.Object);

            var result = await bookController.GetBook(0);

            var okResult = result as BadRequestObjectResult;

            Assert.IsNotNull(okResult);
            Assert.That(400 == okResult.StatusCode);
            Assert.That("Book id must be greater than zero".Equals(okResult.Value));
        }
    }
}
