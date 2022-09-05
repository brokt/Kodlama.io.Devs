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

namespace Application.Features.ProgramingLangue.Commands.DeleteProgramingLangue
{
    public class DeleteProgramingLangueCommand : IRequest<DeletedProgrammingLanguageDtos>
    {
        public int Id { get; set; }

        public class DeleteProgramingLangueHandler : IRequestHandler<DeleteProgramingLangueCommand, DeletedProgrammingLanguageDtos>
        {
            private readonly IProgramingLanguesRepository _programingLanguesRepository;
            private readonly ProgramingLangueBusinessRules _programingLangueBusinessRules;

            public DeleteProgramingLangueHandler(IProgramingLanguesRepository programingLanguesRepository, ProgramingLangueBusinessRules programingLangueBusinessRules)
            {
                _programingLanguesRepository = programingLanguesRepository;
                _programingLangueBusinessRules = programingLangueBusinessRules;
            }
            public async Task<DeletedProgrammingLanguageDtos> Handle(DeleteProgramingLangueCommand request, CancellationToken cancellationToken)
            {
                var programLanguesEntity = await _programingLanguesRepository.GetAsync(g => g.Id == request.Id);
                _programingLangueBusinessRules.ProgramingLangueShouldExistWhenRequested(programLanguesEntity);
                var deleteProgramingLanguage = await _programingLanguesRepository.DeleteAsync(programLanguesEntity);
                return deleteProgramingLanguage.Adapt<DeletedProgrammingLanguageDtos>();
            }
        }
    }
}

