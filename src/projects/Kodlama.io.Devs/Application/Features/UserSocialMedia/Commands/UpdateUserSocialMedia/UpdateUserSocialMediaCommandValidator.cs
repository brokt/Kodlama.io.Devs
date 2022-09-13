using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.UserSocialMedia.Commands.UpdateUserSocialMedia
{
    public class UpdateUserSocialMediaCommandValidator : AbstractValidator<UpdateUserSocialMediaCommand>
    {
        public UpdateUserSocialMediaCommandValidator()
        {
            RuleFor(f => f.Link).NotEmpty();
            RuleFor(f => f.UserId).GreaterThan(0);
            RuleFor(f => f.SocialMediaTypesId).GreaterThan(0);
        }
    }
}
