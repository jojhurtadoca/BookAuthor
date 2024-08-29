using BookAuthor.Models.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserRoles.Dto;
using UserRoles.Exceptions;
using UserRoles.Services.IService;

namespace UserRoles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly ILogger<UserController> _logger; // ILogger takes the type of the class as a parameter
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        private ObjectResult CreateInternalServerErrorResponse()
        {
            return new ObjectResult("Error, the system could not process your request, please try later") { StatusCode = 500 };
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO t)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var created = await _userService.Create(t);

                    if (created == null)
                    {
                        return CreateInternalServerErrorResponse();
                    }

                    return Ok(created);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return CreateInternalServerErrorResponse();
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDTO T)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updated = await _userService.Update(T);

                    if (updated == null)
                    {
                        return CreateInternalServerErrorResponse();
                    }

                    return Ok(updated);
                }
                else
                {
                    return BadRequest(); 
                }                
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return CreateInternalServerErrorResponse();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _userService.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(entity);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var entity = await _userService.GetById(id);
                if (entity == null)
                {
                    return NotFound();
                }
                var deleted = await _userService.Delete(id);
                if (deleted == false)
                {
                    return CreateInternalServerErrorResponse();
                }
                return Ok();
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return CreateInternalServerErrorResponse();
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetPaginated(int page = 1, int limit = 10)
        {
            if (page < 1 || limit < 1)
            {
                return BadRequest();
            }
            try
            {
                var entities = await _userService.GetResultPaginated(page, limit);
                if (entities == null)
                {
                    return NotFound();
                }
                return Ok(entities);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return CreateInternalServerErrorResponse();
            }

        }
    }
}
