using Application.Features.ProgramingTechnology.Dtos;
using Application.Features.ProgramingTechnology.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingTechnology.Commands.UpdateProgramingTechnology
{
    public class UpdateProgramingTechnologyCommand : IRequest<UpdatedProgramingTechnologyDtos>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgramingLanguesId { get; set; }

        public class UpdateProgramingTechnologyHandler : IRequestHandler<UpdateProgramingTechnologyCommand, UpdatedProgramingTechnologyDtos>
        {
            private readonly IProgramingTechnologiesRepository _programingTechnologyRepository;
            private readonly ProgramingTechnologyBusinessRules _programingTechnologyBusinessRules;

            public UpdateProgramingTechnologyHandler(IProgramingTechnologiesRepository programingTechnologyRepository, ProgramingTechnologyBusinessRules programingTechnologyBusinessRules)
            {
                _programingTechnologyRepository = programingTechnologyRepository;
                _programingTechnologyBusinessRules = programingTechnologyBusinessRules;
            }
            public async Task<UpdatedProgramingTechnologyDtos> Handle(UpdateProgramingTechnologyCommand request, CancellationToken cancellationToken)
            {               
                var entity = request.Adapt<ProgramingTechnologies>();
                await _programingTechnologyBusinessRules.ProgramingTechnologyCheckEntityIfEmpty(entity);
                await _programingTechnologyBusinessRules.ProgramingTechnologyCheckNameIsExist(entity.Name);
                var updatedProgramTechnologyEntity = await _programingTechnologyRepository.UpdateAsync(entity);
                return updatedProgramTechnologyEntity.Adapt<UpdatedProgramingTechnologyDtos>();
            }
        }
    }
}
