using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(f => f.Email).EmailAddress().NotEmpty();
            RuleFor(f => f.Password).NotEmpty();
            RuleFor(f => f.LastName).NotEmpty();
            RuleFor(f => f.FirstName).NotEmpty();
        }
    }
}
