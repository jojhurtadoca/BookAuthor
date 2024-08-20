using BookAuthor.Controllers;
using BookAuthor.Models.Dto;
using BookAuthor.Models.Exceptions;
using BookAuthor.Service.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.Json;

namespace BookAuthor.Test.Controller
{
    [TestFixture]
    public class BookControllerTest {

        private BookController bookController;
        private BookDTO Book = new BookDTO();
        private CreateBookDTO CreateBook = new CreateBookDTO();
        private GenreDTO Genre = new GenreDTO();
        private AuthorDTO Author = new AuthorDTO();

        public BookControllerTest()
        {
            CreateBook.Author = 1;
            CreateBook.Title = "Test title";
            CreateBook.Description = "Test description";
            CreateBook.Price = 1000;
            CreateBook.Genre = 1;

            Genre.Id = 1;
            Genre.Name = "Genre test 1";

            Author.Id = 1;
            Author.Name = "Author name 1";

            Book.Id = 1;
            Book.Title = "Test title";
            Book.Description = "Test description";
            Book.Price = 1000;
            Book.Genre = Genre;
            Book.Author = Author;
        }

        [Test]
        public async Task CreateBookTestOK()
        {
            var mock = new Mock<ILogger<BookController>>();
            ILogger<BookController> logger = mock.Object;


            var mockService = new Mock<IBookService>();

            mockService.Setup(p => p.CreateBook(CreateBook)).Returns(Task.FromResult(Book));

            bookController = new BookController(mock.Object, mockService.Object);

            var result = await bookController.CreateBook(CreateBook);

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

            mockService.Setup(p => p.CreateBook(CreateBook)).Throws(new NotFoundException("Author with id '1' doesn't exist"));

            bookController = new BookController(mock.Object, mockService.Object);

            var result = await bookController.CreateBook(CreateBook);

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

            mockService.Setup(p => p.GetBookById(1)).Returns(Task.FromResult(Book));

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
