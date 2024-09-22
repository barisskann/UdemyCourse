using FluentValidation;

namespace Services.Products;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Ürün ismi gereklidir")
             .Length(3, 10).WithMessage("Ürün ismi 3 ile 10 karakter arasında olabilir.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır");

        RuleFor(x => x.stock)
            .InclusiveBetween(1, 100).WithMessage("Stock adedi 1 ile 100 arasında olmalıdır");
    }
}
