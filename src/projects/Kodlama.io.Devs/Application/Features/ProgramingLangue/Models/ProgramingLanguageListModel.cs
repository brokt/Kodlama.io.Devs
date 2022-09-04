using Application.Features.ProgramingLangue.Dtos;
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
        public IList<ProgramingLanguageListDtos> Items { get; set; }
    }
}
