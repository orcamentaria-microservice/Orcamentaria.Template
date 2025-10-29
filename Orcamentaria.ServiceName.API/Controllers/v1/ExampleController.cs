using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamentaria.Lib.Domain.Models;
using Orcamentaria.ServiceName.Domain.DTOs.Example;
using Orcamentaria.ServiceName.Domain.Services;

namespace Orcamentaria.ServiceName.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExampleController : Controller
    {
        private readonly IExampleService _service;

        public ExampleController(IExampleService service)
        {
            _service = service;
        }

        [Authorize(Roles = "EXAMPLE:READ")]
        [HttpGet("GetById/{id}", Name = "ExampleGetById")]
        public Response<ExampleResponseDTO> GetById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
