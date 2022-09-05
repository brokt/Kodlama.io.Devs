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

namespace Application.Features.ProgramingLangue.Commands.UpdateProgramingLangue
{

    public class UpdateProgramingLangueCommand : IRequest<UpdatedProgrammingLanguageDtos>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramingLangueHandler : IRequestHandler<UpdateProgramingLangueCommand, UpdatedProgrammingLanguageDtos>
        {
            private readonly IProgramingLanguesRepository _programingLanguesRepository;
            private readonly ProgramingLangueBusinessRules _programingLangueBusinessRules;

            public UpdateProgramingLangueHandler(IProgramingLanguesRepository programingLanguesRepository, ProgramingLangueBusinessRules programingLangueBusinessRules)
            {
                _programingLanguesRepository = programingLanguesRepository;
                _programingLangueBusinessRules = programingLangueBusinessRules;
            }
            public async Task<UpdatedProgrammingLanguageDtos> Handle(UpdateProgramingLangueCommand request, CancellationToken cancellationToken)
            {
                var entity = request.Adapt<ProgramingLangues>();
                await _programingLangueBusinessRules.ProgramingLangueCheckEntityIfEmpty(entity);
                await _programingLangueBusinessRules.ProgramingLangueCheckNameIsExist(entity.Name);
                var updatedProgramLanguesEntity = await _programingLanguesRepository.UpdateAsync(entity);
                return updatedProgramLanguesEntity.Adapt<UpdatedProgrammingLanguageDtos>();
            }
        }
    }
}
