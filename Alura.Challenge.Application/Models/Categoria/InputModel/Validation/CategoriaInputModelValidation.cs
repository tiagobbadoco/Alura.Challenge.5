using FluentValidation;

namespace Alura.Challenge.Application.Models.InputModel.Validation
{
    public class CategoriaInputModelValidation : AbstractValidator<CategoriaInputModel>
    {
        public CategoriaInputModelValidation()
        {
            RuleFor(x => x.Titulo).NotEmpty().WithMessage("O título é obrigatório");

            RuleFor(x => x.Cor).NotEmpty().WithMessage("A cor é obrigatória");
        }
    }
}