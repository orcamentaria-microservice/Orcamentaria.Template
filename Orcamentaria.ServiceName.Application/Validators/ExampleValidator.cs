using FluentValidation;
using FluentValidation.Results;
using Orcamentaria.Lib.Domain.Validators;
using Orcamentaria.ServiceName.Domain.Models;
using Orcamentaria.ServiceName.Domain.Repositories;

namespace Orcamentaria.ServiceName.Application.Validators
{
    public class ExampleValidator : AbstractValidator<Example>, IValidatorEntity<Example>
    {
        private readonly IExampleRepository _repository;

        public ExampleValidator(IExampleRepository repository)
        {
            _repository = repository;
        }

        public void CommonValidation(Example entity)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O {PropertyName} é obrigatório.")
                .NotNull().WithMessage("O {PropertyName} é obrigatório.")
                .MaximumLength(100).WithMessage("O tamanho máximo do {PropertyName} é de {MaxLength} caracteres.");
        }

        public ValidationResult ValidateBeforeInsert(Example entity)
        {
            CommonValidation(entity);

            RuleFor(x => x.Id)
                .Empty().WithMessage("O {PropertyName} não deve ser informado.");

            return Validate(entity);
        }

        public ValidationResult ValidateBeforeUpdate(Example entity)
        {
            CommonValidation(entity);

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O {PropertyName} deve ser informado.");

            return Validate(entity);
        }
    }
}
