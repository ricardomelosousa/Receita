using Project.Recipes.Api.Model;
using FluentValidation;

namespace Project.Recipes.Api.Validator
{
    public class AuthenticateRequestValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateRequestValidator()
        {
            RuleFor(a => a.Login).NotNull().WithMessage("É necessário informar o login.");
            RuleFor(a => a.Login).NotNull().WithMessage("É necessário informar a Password.");
        }
    }
}
