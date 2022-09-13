using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.UserSocialMedia.Commands.DeleteUserSocialMedia
{
    public class DeleteUserSocialMediaCommandValidator : AbstractValidator<DeleteUserSocialMediaCommand>
    {
        public DeleteUserSocialMediaCommandValidator()
        {
            RuleFor(f => f.Id).NotEmpty().GreaterThan(0);
        }
    }
}
