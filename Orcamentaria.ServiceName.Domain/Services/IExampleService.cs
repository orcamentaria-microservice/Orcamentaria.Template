using Orcamentaria.Lib.Domain.Models;
using Orcamentaria.ServiceName.Domain.DTOs.Example;

namespace Orcamentaria.ServiceName.Domain.Services
{
    public interface IExampleService
    {
        Response<ExampleResponseDTO> GetById(long id);
    }
}
