using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLangue.Commands.DeleteProgramingLangue
{
    public class DeleteProgramingLanguageCommandValidator : AbstractValidator<DeleteProgramingLangueCommand>
    {
        public DeleteProgramingLanguageCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
