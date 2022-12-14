using Application.Features.ProgramingLangue.Dtos;
using Application.Features.ProgramingTechnology.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLangue.Models
{
    public class ProgramingLanguageListModel : BasePageableModel
    {
        public IList<ProgrammingTechnologyListDtos> Items { get; set; }
    }
}
