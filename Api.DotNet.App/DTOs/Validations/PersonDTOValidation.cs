

using FluentValidation;

namespace Api.DotNet.App.DTOs.Validations
{
    public class PersonDTOValidation : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidation()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado!");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Telefone deve ser informado!");

        }
    }
}
