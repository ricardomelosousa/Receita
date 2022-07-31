using Fiap.Project.Recipes.Domain.Models;
using FluentValidation;

namespace Fiap.Project.Recipes.Api.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Login).NotNull().WithMessage("Login deve ser informado");
            RuleFor(a => a.Senha).NotNull().WithMessage("Senha deve ser informada");
            RuleFor(a => a.Nome).NotNull().WithMessage("Nome deve ser informado.");
            RuleFor(a => a.Email).NotNull().WithMessage("Email deve ser informado");
        }
    }
}
