using APIModeloDDD.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIModeloDDD.Domain.Validations
{
    public class PersonPostValidator : AbstractValidator<Person>
    {
        public PersonPostValidator()
        {
            RuleFor(x => x.email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Email é obrigatório");

            RuleFor(x => x.senha)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Senha é obrigatório");

            RuleFor(x => x.nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(x => x.birthdate)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Data de Nascimento é obrigatório");
        }
    }
}
