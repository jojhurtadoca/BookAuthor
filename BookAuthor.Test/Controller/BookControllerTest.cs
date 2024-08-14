using BookAuthor.Controllers;
using BookAuthor.Service.Service.IService;
using Microsoft.Extensions.Logging;
using Moq;

namespace BookAuthor.Test.Controller
{
    [TestFixture]
    public class BookControllerTest {

        private BookController bookController;

        [SetUp]
        public void SetUp()
        {
            var mock = new Mock<ILogger<BookController>>();
            ILogger<BookController> logger = mock.Object;

            var mockService = new Mock<IBookService>();

            bookController = new BookController(mock.Object, mockService.Object);
        }

        [Test]
        public void CreateBookTest()
        {

        }

        [Test]
        public void GetTheMostExpensiveBookTest()
        {

        }
    }
}
