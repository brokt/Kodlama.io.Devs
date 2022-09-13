using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.UserSocialMedia.Commands.CreateUserSocialMedia
{
    public class CreateUserSocialMediaCommandValidator : AbstractValidator<CreateUserSocialMediaCommand>
    {
        public CreateUserSocialMediaCommandValidator()
        {
            RuleFor(f => f.Link).NotEmpty();
            RuleFor(f => f.UserId).NotEmpty().GreaterThan(0);
            RuleFor(f => f.SocialMediaTypesId).NotEmpty().GreaterThan(0);
        }
    }
}
