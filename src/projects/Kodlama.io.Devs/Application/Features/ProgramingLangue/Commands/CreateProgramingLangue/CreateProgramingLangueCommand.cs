using Application.Features.ProgramingLangue.Dtos;
using Application.Features.ProgramingLangue.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLangue.Commands.CreateProgramingLangue
{
    public class CreateProgramingLangueCommand : IRequest<CreatedProgramingLangueDtos>
    {
        public string Name { get; set; }

        public class CreateProgramingLangueHandler : IRequestHandler<CreateProgramingLangueCommand, CreatedProgramingLangueDtos>
        {
            private readonly IProgramingLanguesRepository _programingLanguesRepository;
            private readonly ProgramingLangueBusinessRules _programingLangueBusinessRules;

            public CreateProgramingLangueHandler(IProgramingLanguesRepository programingLanguesRepository,ProgramingLangueBusinessRules programingLangueBusinessRules)
            {
                _programingLanguesRepository = programingLanguesRepository;
                _programingLangueBusinessRules = programingLangueBusinessRules;
            }
            public async Task<CreatedProgramingLangueDtos> Handle(CreateProgramingLangueCommand request, CancellationToken cancellationToken)
            {
                await _programingLangueBusinessRules.ProgramingLangueNameCanNotBeDuplicatedWhenInserted(request.Name);
                var createProgramLanguesEntity =  await _programingLanguesRepository.AddAsync(request.Adapt<ProgramingLangues>());
                return createProgramLanguesEntity.Adapt<CreatedProgramingLangueDtos>();
            }
        }
    }
}
