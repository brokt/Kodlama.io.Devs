using Core.Application.Pipelines.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLangue.Queries.GetListProgramingLanguage
{
    public class GetListProgramingLanguageQueryAuthorize : ISecuredRequest
    {
        public string[] Roles => new[] { "Admin" };
        public GetListProgramingLanguageQueryAuthorize()
        {

        }
    }
}
