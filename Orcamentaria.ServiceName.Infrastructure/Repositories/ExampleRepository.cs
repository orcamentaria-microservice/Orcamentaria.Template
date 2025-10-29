using Orcamentaria.Lib.Domain.Exceptions;
using Orcamentaria.ServiceName.Domain.Models;
using Orcamentaria.ServiceName.Domain.Repositories;
using Orcamentaria.ServiceName.Infrastructure.Contexts;

namespace Orcamentaria.ServiceName.Infrastructure.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly MySqlContext _dbContext;

        public ExampleRepository(MySqlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Example? GetById(long id)
        {
            try
            {
                return _dbContext.Examples.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message, ex);
            }
        }
    }
}
