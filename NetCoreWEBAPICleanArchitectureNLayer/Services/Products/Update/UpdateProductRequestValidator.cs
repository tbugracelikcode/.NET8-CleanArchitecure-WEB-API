using FluentValidation;

namespace App.Services.Products.Update
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Product name is required")
              .Length(3, 10).WithMessage("Product name must be between 3 and 10 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than 0");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category Id must ne greater than 0");


            RuleFor(x => x.Stock)
                .InclusiveBetween(0, 500).WithMessage("Stock quantity must be between 0 and 500");
        }
    }
}
