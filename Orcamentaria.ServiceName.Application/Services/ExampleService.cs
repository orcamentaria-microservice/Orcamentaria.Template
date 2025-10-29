using AutoMapper;
using Orcamentaria.Lib.Domain.Enums;
using Orcamentaria.Lib.Domain.Exceptions;
using Orcamentaria.Lib.Domain.Models;
using Orcamentaria.Lib.Domain.Models.Exceptions;
using Orcamentaria.Lib.Domain.Validators;
using Orcamentaria.ServiceName.Domain.DTOs.Example;
using Orcamentaria.ServiceName.Domain.Models;
using Orcamentaria.ServiceName.Domain.Repositories;
using Orcamentaria.ServiceName.Domain.Services;

namespace Orcamentaria.ServiceName.Application.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository _repository;
        private readonly IValidatorEntity<Example> _validator;
        private readonly IMapper _mapper;

        public ExampleService(
            IExampleRepository repository,
            IValidatorEntity<Example> validator,
            IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public Response<ExampleResponseDTO> GetById(long id)
        { 
            try
            {
                var entity = _repository.GetById(id);

                if(entity is null)
                    throw new InfoException($"O {id} não foi encontrado.", ErrorCodeEnum.NotFound);

                return new Response<ExampleResponseDTO>(_mapper.Map<Example, ExampleResponseDTO>(entity));
            }
            catch (DefaultException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(ex.Message, ex);
            }
        }
    }
}
