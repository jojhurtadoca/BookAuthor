using BookAuthor.Models.Dto;
using BookAuthor.Models.Exceptions;
using BookAuthor.Service.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace BookAuthor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger; // ILogger takes the type of the class as a parameter
        private readonly IBookService _bookService; // readonly means that the variable can only be assigned a value in the constructor

        public BookController(
            ILogger<BookController> logger,
            IBookService bookService
            )
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <returns>Book created.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var book = await _bookService.CreateBook(dto);
                    if (book == null)
                    {
                        throw new Exception();
                    }
                    return CreateJsonResult(201, "Book created successfully", book);
                }
                catch(NotFoundException ex)
                {
                    _logger.LogError(ex.Message, ex);
                    return NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                    return CreateInternalServerError("The system can't create books now, please try later");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        /// <summary>
        /// Get book by id
        /// </summary>
        /// <returns>Book by id.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            try
            {
                var result = await _bookService.GetBookById(id);
                return CreateJsonResult(201, "", result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return CreateInternalServerError("The system can't get books now, please try later");
            }
        }

        /// <summary>
        /// Updates book by id and DTO
        /// </summary>
        /// <returns>Json Result.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(UpdateBookDTO dto)
        {

            try
            {
                var result = await _bookService.UpdateBook(dto);
                return CreateJsonResult(200, "Book updated Successfully", null);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return CreateInternalServerError("The system can't get books now, please try later");
            }
        }

        /// <summary>
        /// Deletes a book by id
        /// </summary>
        /// <returns>Json Result.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                var result = await _bookService.DeleteBook(id);
                return CreateJsonResult(200, "Book deleted Successfully", null);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex.Message, ex);
                return CreateInternalServerError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return CreateInternalServerError("The system can't delete books now, please try later");
            }
        }

        /// <summary>
        /// Gets list of books
        /// </summary>
        /// <returns>List of books.</returns>
        [HttpGet]
        public async Task<IActionResult> GetBoooks(int pageNumber = 1, int pageSize = 10, Boolean orderByAsc = true)
        {
            if (pageNumber <= 0)
            {
                return BadRequest("Page Number can't be less or equal to zero");
            }
            if (pageSize <= 0)
            {
                return BadRequest("Page Size can't be less or equal to zero");
            }
            try
            {
                var books = await _bookService.GetBooks(pageNumber, pageSize, orderByAsc);
                return CreateJsonResult(201, "Books got successfully", books);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return CreateInternalServerError("The system can't get books now, please try later");
            }
        }

        /// <summary>
        /// Filters books by author
        /// </summary>
        /// <returns>The list of the books filtered by Author.</returns>
        [HttpGet("/filter/author")]
        public async Task<IActionResult> GetBoooksByAuthor(Guid authorId, int pageNumber = 1, int pageSize = 10, Boolean orderByAsc = true)
        {
            if (pageNumber <= 0)
            {
                return BadRequest("Page Number can't be less or equal to zero");
            }
            if (pageSize <= 0)
            {
                return BadRequest("Page Size can't be less or equal to zero");
            }
            try
            {
                var books = await _bookService.FilterBooksByAuthor(authorId, pageNumber, pageSize, orderByAsc);
                return CreateJsonResult(201, "Books related to the author with id '" +  authorId + "' got successfully", books);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return CreateInternalServerError("The system can't get books now, please try later");
            }
        }

        /// <summary>
        /// Filters books by Genre
        /// </summary>
        /// <returns>The list of the books filtered by Genre.</returns>
        [HttpGet("/filter/genre")]
        public async Task<IActionResult> GetBoooksByGenre(Guid genreId, int pageNumber = 1, int pageSize = 10, Boolean orderByAsc = true)
        {
            if (pageNumber <= 0)
            {
                return BadRequest("Page Number can't be less or equal to zero");
            }
            if (pageSize <= 0)
            {
                return BadRequest("Page Size can't be less or equal to zero");
            }
            try
            {
                var books = await _bookService.FilterBooksByGenre(genreId, pageNumber, pageSize, orderByAsc);
                return CreateJsonResult(201, "Books related to the genre id '" + genreId + "' got successfully", books);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return CreateInternalServerError("The system can't get books now, please try later");
            }
        }

        /// <summary>
        /// Gets the most expensive book
        /// </summary>
        /// <returns>The most expensive book.</returns>
        [HttpGet("/most-expensive")]
        public async Task<IActionResult> GetTheMostExpensiveBook()
        {
            try
            {
                var result = await _bookService.GetTheMostExpensiveBook();
                return CreateJsonResult(201, "Book got successfully", result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return CreateInternalServerError("The system can't get books now, please try later");
            }
        }

        /// <summary>
        /// Gets the cheapest book
        /// </summary>
        /// <returns>The cheapest book.</returns>
        [HttpGet("/cheapest")]
        public async Task<IActionResult> GetTheCheapestBook()
        {
            try
            {
                var result = await _bookService.GetTheCheapestBook();
                return CreateJsonResult(201, "Book got successfully", result);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return CreateInternalServerError("The system can't get books now, please try later");
            }
        }

        private IActionResult CreateInternalServerError(string message)
        {
            return StatusCode(500, message);
        }

        private JsonResult CreateJsonResult(int status, string message, object content)
        {
            if (message == null || message == "")
            {
                return new JsonResult(new
                {
                    StatusCode = status,
                    Content = content
                })
                {
                    StatusCode = status
                };
            }
            if (content == null)
            {
                return new JsonResult(new
                {
                    StatusCode = status,
                    Message = message,
                })
                {
                    StatusCode = status
                };
            }
            return new JsonResult(new
            {
                StatusCode = status,
                Message = message,
                Content = content
            })
            {
                StatusCode = status
            };
        }
    }
}
