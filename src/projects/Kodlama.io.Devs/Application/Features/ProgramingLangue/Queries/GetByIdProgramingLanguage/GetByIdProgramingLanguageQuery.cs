using Application.Features.ProgramingLangue.Dtos;
using Application.Features.ProgramingLangue.Models;
using Application.Features.ProgramingLangue.Rules;
using Application.Services.Repositories;
using Core.Application.Requests;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLangue.Queries.GetByIdProgramingLanguage
{
    public class GetByIdProgramingLanguageQuery : IRequest<ProgramingLanguageGetByIdDtos>
    {
        public int Id { get; set; }

        public class GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery, ProgramingLanguageGetByIdDtos>
        {
            private readonly IProgramingLanguesRepository _programingLanguesRepository;
            private readonly ProgramingLangueBusinessRules _programingLangueBusinessRules;

            public GetByIdProgramingLanguageQueryHandler(IProgramingLanguesRepository programingLanguesRepository,ProgramingLangueBusinessRules programingLangueBusinessRules)
            {
                _programingLanguesRepository = programingLanguesRepository;
                _programingLangueBusinessRules = programingLangueBusinessRules;
            }
            public async Task<ProgramingLanguageGetByIdDtos> Handle(GetByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                var result = await _programingLanguesRepository.GetAsync(g => g.Id == request.Id);
                _programingLangueBusinessRules.ProgramingLangueCheckEntityIfEmpty(result);
                return result.Adapt<ProgramingLanguageGetByIdDtos>();
            }
        }
    }
}
