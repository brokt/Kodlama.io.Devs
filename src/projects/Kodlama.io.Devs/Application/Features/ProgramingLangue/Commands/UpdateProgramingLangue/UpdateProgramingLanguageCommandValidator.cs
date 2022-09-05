using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLangue.Commands.UpdateProgramingLangue
{
    public class UpdateProgramingLanguageCommandValidator : AbstractValidator<UpdateProgramingLangueCommand>
    {
        public UpdateProgramingLanguageCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
        }
    }
}
