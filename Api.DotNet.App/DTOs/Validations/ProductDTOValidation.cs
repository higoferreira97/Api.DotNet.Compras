using FluentValidation;

namespace Api.DotNet.App.DTOs.Validations
{
    public class ProductDTOValidation : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidation()
        {
            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("CodErp deve ser informado!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado!");

            RuleFor(x => x.Price)
                .GreaterThan(0) //Preço maior que zero
                .WithMessage("Preço deve ser maior que zero");

        }
    }
}
