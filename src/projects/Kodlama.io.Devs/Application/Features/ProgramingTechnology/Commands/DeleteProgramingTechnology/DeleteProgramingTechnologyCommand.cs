using Application.Features.ProgramingTechnology.Dtos;
using Application.Features.ProgramingTechnology.Rules;
using Application.Services.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingTechnology.Commands.DeleteProgramingTechnology
{
    public class DeleteProgramingTechnologyCommand : IRequest<DeletedProgramingTechnologyDtos>
    {
        public int Id { get; set; }

        public class DeleteProgramingTechnologyHandler : IRequestHandler<DeleteProgramingTechnologyCommand, DeletedProgramingTechnologyDtos>
        {
            private readonly IProgramingTechnologiesRepository _programingTechnologysRepository;
            private readonly ProgramingTechnologyBusinessRules _programingTechnologyBusinessRules;

            public DeleteProgramingTechnologyHandler(IProgramingTechnologiesRepository programingTechnologiesRepository, ProgramingTechnologyBusinessRules programingTechnologyBusinessRules)
            {
                _programingTechnologysRepository = programingTechnologiesRepository;
                _programingTechnologyBusinessRules = programingTechnologyBusinessRules;
            }
            public async Task<DeletedProgramingTechnologyDtos> Handle(DeleteProgramingTechnologyCommand request, CancellationToken cancellationToken)
            {
                var programTechnologysEntity = await _programingTechnologysRepository.GetAsync(g => g.Id == request.Id);
                _programingTechnologyBusinessRules.ProgramingTechnologyShouldExistWhenRequested(programTechnologysEntity);
                var deleteProgramingLanguage = await _programingTechnologysRepository.DeleteAsync(programTechnologysEntity);
                return deleteProgramingLanguage.Adapt<DeletedProgramingTechnologyDtos>();
            }
        }
    }
}
