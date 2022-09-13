using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingTechnology.Commands.CreateProgramingTechnology
{
    public class CreateProgramingTechnologyCommandValidator : AbstractValidator<CreateProgramingTechnologyCommand>
    {
        public CreateProgramingTechnologyCommandValidator()
        {
            RuleFor(f => f.Name).NotEmpty();
            RuleFor(f => f.ProgramingLanguesId).GreaterThan(0);
        }
    }
}
