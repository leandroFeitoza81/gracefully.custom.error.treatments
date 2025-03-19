using CodeMasterDev.Core.Domain.Models;
using FluentValidation;

namespace CodeMasterDev.Core.Services.Validator
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(actor => actor.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O nome do ator é obrigatório")
                .MaximumLength(100).WithMessage("O nome do ator deve ter no máximo 100 caracteres");
        }

    }
}
