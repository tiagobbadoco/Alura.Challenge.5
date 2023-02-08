using FluentValidation;

namespace Alura.Challenge.Application.Models.InputModel.Validation
{
    public class VideoInputModelValidation : AbstractValidator<VideoInputModel>
    {
        public VideoInputModelValidation()
        {
            RuleFor(x => x.Titulo).NotEmpty().WithMessage("O título é obrigatório.");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("A descrição é obrigatória.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("A URL é obrigatória.");
        }
    }
}