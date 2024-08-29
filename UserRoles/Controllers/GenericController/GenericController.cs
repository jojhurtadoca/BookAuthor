using BookAuthor.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using UserRoles.Services.IService;

namespace UserRoles.Controllers.GenericController
{
    [ApiController]
    public abstract class GenericController<GetT, CreateT, UpdateT, TService> : Controller
        where GetT : class
        where CreateT : class
        where UpdateT : class
        where TService : IService<GetT, CreateT, UpdateT>, new()
    {
        private IService<GetT, CreateT, UpdateT> service;
        public GenericController()
        { 
            this.service = new TService();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateT t)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var created = await this.service.Create(t);

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
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return CreateInternalServerErrorResponse();
            }            
        }

        public async Task<IActionResult> Update(UpdateT T)
        {
            try
            {
                var updated = await this.service.Update(T);

                if (updated == null)
                {
                    return CreateInternalServerErrorResponse();
                }

                return Ok(updated);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return CreateInternalServerErrorResponse();
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var entity = await this.service.GetById(id);
                if (entity == null)
                {
                    return NotFound();
                }
                var deleted = await this.service.Delete(id);
                if (deleted == false)
                {
                    return CreateInternalServerErrorResponse();
                }
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return CreateInternalServerErrorResponse();
            }

        }

        public async Task<IActionResult> GetPaginated(int page = 1, int limit = 10)
        {
            try
            {
                var entities = await this.service.GetResultPaginated(page, limit);
                if (entities == null)
                {
                    return NotFound();
                }
                return Ok(entities);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return CreateInternalServerErrorResponse();
            }

        }

        private ObjectResult CreateInternalServerErrorResponse()
        {
            return new ObjectResult("Error, the system could not process your request, please try later") { StatusCode = 500 };
        }
    }
}
