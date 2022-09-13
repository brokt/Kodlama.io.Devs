using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingTechnology.Commands.UpdateProgramingTechnology
{
    public class UpdateProgramingTechnologyCommandValidator : AbstractValidator<UpdateProgramingTechnologyCommand>
    {
        public UpdateProgramingTechnologyCommandValidator()
        {
            RuleFor(f => f.Id).NotEmpty();
            RuleFor(f => f.Name).NotEmpty();
        }
    }
}
