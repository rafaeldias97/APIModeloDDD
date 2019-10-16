using APIModeloDDD.Domain.Models;
using FluentValidation;

namespace APIModeloDDD.Domain.Validations
{
    public class PersonAuthValidator : AbstractValidator<Person>
    {
        public PersonAuthValidator()
        {
            RuleFor(x => x.email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Email é obrigatório");

            RuleFor(x => x.senha)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Senha é obrigatório");
        }
    }
}
