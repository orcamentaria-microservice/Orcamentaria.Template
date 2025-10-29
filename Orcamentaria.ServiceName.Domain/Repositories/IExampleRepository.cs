using Orcamentaria.ServiceName.Domain.Models;

namespace Orcamentaria.ServiceName.Domain.Repositories
{
    public interface IExampleRepository
    {
        Example? GetById(long id);
    }
}
