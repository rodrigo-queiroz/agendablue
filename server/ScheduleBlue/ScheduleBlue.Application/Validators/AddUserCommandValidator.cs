using FluentValidation;
using ScheduleBlue.Application.Commands.AddUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScheduleBlue.Application.Validators
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Nome é Obrigatório");

            RuleFor(e => e.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido");

            RuleFor(p => p.Telephone)
                .MinimumLength(10)
                .WithMessage("Seu telefone deve conter pelo menos 11 números.");
        }
    }
}
