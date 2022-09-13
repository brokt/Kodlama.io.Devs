using Application.Features.ProgramingTechnology.Dtos;
using Application.Features.ProgramingTechnology.Rules;
using Application.Services.Repositories;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingTechnology.Queries.GetByIdProgramingTechnology
{

    public class GetByIdProgramingTechnologyQuery : IRequest<ProgramingTechnologyGetByIdDtos>
    {
        public int Id { get; set; }

        public class GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingTechnologyQuery, ProgramingTechnologyGetByIdDtos>
        {
            private readonly IProgramingTechnologiesRepository _programingTechnologyRepository;
            private readonly ProgramingTechnologyBusinessRules _programingTechnologyBusinessRules;

            public GetByIdProgramingLanguageQueryHandler(IProgramingTechnologiesRepository programingTechnologyRepository, ProgramingTechnologyBusinessRules programingTechnologyBusinessRules)
            {
                _programingTechnologyRepository = programingTechnologyRepository;
                _programingTechnologyBusinessRules = programingTechnologyBusinessRules;
            }
            public async Task<ProgramingTechnologyGetByIdDtos> Handle(GetByIdProgramingTechnologyQuery request, CancellationToken cancellationToken)
            {
                var result = await _programingTechnologyRepository.GetAsync(g => g.Id == request.Id,include: m => m.Include(i => i.ProgramingLangues));
                _programingTechnologyBusinessRules.ProgramingTechnologyShouldExistWhenRequested(result);
                return result.Adapt<ProgramingTechnologyGetByIdDtos>();
            }
        }
    }
}
