using Application.Features.ProgramingLangue.Dtos;
using Application.Features.ProgramingLangue.Models;
using Application.Services.Repositories;
using Core.Application.Requests;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLangue.Queries.GetListProgramingLanguage
{
    public class GetListProgramingLanguageQuery : IRequest<ProgramingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgramingLanguageQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, ProgramingLanguageListModel>
        {
            private readonly IProgramingLanguesRepository _programingLanguesRepository;

            public GetListProgramingLanguageQueryHandler(IProgramingLanguesRepository programingLanguesRepository)
            {
                _programingLanguesRepository = programingLanguesRepository;
            }
            public async Task<ProgramingLanguageListModel> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                var result = await _programingLanguesRepository.GetListAsync(size: request.PageRequest.PageSize, index: request.PageRequest.Page);
                return result.Adapt<ProgramingLanguageListModel>();
            }
        }
    }
}
