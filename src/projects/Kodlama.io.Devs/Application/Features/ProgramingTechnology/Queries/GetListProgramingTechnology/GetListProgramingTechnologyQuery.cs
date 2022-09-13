using Application.Features.ProgramingLangue.Models;
using Application.Features.ProgramingTechnology.Dtos;
using Application.Services.Repositories;
using Core.Application.Requests;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingTechnology.Queries.GetListProgramingTechnology
{

    public class GetListProgramingTechnologyQuery : IRequest<ProgramingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgramingTechnologyQueryHandler : IRequestHandler<GetListProgramingTechnologyQuery, ProgramingLanguageListModel>
        {
            private readonly IProgramingTechnologiesRepository _programingTechnologyRepository;

            public GetListProgramingTechnologyQueryHandler(IProgramingTechnologiesRepository programingTechnologyRepository)
            {
                _programingTechnologyRepository = programingTechnologyRepository;
            }
            public async Task<ProgramingLanguageListModel> Handle(GetListProgramingTechnologyQuery request, CancellationToken cancellationToken)
            {
                var result = await _programingTechnologyRepository.GetListAsync(include: m => m.Include(i => i.ProgramingLangues),size: request.PageRequest.PageSize, index: request.PageRequest.Page);
                return result.Adapt<ProgramingLanguageListModel>();
            }
        }
    }
}
