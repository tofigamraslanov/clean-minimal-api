using Products.Api.Contracts.Requests;

namespace Products.Api.Validators;

public class UpdateProductRequestValidator : Validator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("Id can not be empty");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Name can not be empty")
            .MinimumLength(2)
            .WithMessage("Name should be at least 2 characters");

        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("Description can not be empty")
            .MinimumLength(6)
            .WithMessage("Description should be at least 6 characters");

        RuleFor(p => p.Price)
            .NotEmpty()
            .WithMessage("Price can not be empty")
            .GreaterThan(0)
            .WithMessage("Price should be greater than 0");

        RuleFor(p => p.Rate)
            .NotEmpty()
            .WithMessage("Rate can not be empty");
    }
}