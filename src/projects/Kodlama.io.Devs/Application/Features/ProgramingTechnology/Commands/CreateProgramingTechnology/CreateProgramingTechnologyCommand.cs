using Application.Features.ProgramingTechnology.Dtos;
using Application.Services.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Features.ProgramingTechnology.Rules;

namespace Application.Features.ProgramingTechnology.Commands.CreateProgramingTechnology
{
    public class CreateProgramingTechnologyCommand : IRequest<CreatedProgramingTechnologyDtos>
    {
        public string Name { get; set; }
        public int ProgramingLanguesId { get; set; }

        public class CreateProgramingTechnologyHandler : IRequestHandler<CreateProgramingTechnologyCommand, CreatedProgramingTechnologyDtos>
        {
            private readonly IProgramingTechnologiesRepository _programingTechnologiesRepository;
            private readonly ProgramingTechnologyBusinessRules _programingTechnologyBusinessRules;

            public CreateProgramingTechnologyHandler(IProgramingTechnologiesRepository programingTechnologiesRepository, ProgramingTechnologyBusinessRules programingTechnologyBusinessRules)
            {
                _programingTechnologiesRepository = programingTechnologiesRepository;
                _programingTechnologyBusinessRules = programingTechnologyBusinessRules;
            }
            public async Task<CreatedProgramingTechnologyDtos> Handle(CreateProgramingTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programingTechnologyBusinessRules.ProgramingTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);
                var createdEntity = await _programingTechnologiesRepository.AddAsync(request.Adapt<ProgramingTechnologies>());
                return createdEntity.Adapt<CreatedProgramingTechnologyDtos>();
            }
        }
    }
}
