using Application.Features.ProgramingTechnology.Commands.CreateProgramingTechnology;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingTechnology.Commands.DeleteProgramingTechnology
{
    public class DeleteProgramingTechnologyCommandValidator : AbstractValidator<DeleteProgramingTechnologyCommand>
    {
        public DeleteProgramingTechnologyCommandValidator()
        {
            RuleFor(f => f.Id).NotEmpty();
        }
    }
}
