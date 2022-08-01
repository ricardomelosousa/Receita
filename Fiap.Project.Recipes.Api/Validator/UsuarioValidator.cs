using Project.Recipes.Domain.Models;
using FluentValidation;

namespace Project.Recipes.Api.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Login).NotNull().WithMessage("Login deve ser informado");
            RuleFor(a => a.Password).NotNull().WithMessage("Password deve ser informada");
            RuleFor(a => a.Name).NotNull().WithMessage("Name deve ser informado.");
            RuleFor(a => a.Email).NotNull().WithMessage("Email deve ser informado");
        }
    }
}
