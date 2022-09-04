using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.ProgramingLangue.Rules
{
    public class ProgramingLangueBusinessRules
    {
        private readonly IProgramingLanguesRepository _programingLanguesRepository;

        public ProgramingLangueBusinessRules(IProgramingLanguesRepository programingLanguesRepository)
        {
            _programingLanguesRepository = programingLanguesRepository;
        }

        public async Task ProgramingLangueNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingLangues> result = await _programingLanguesRepository.GetListAsync(b => b.Name.ToLower() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException("Programing Langue name is exists.");
        }
        public async Task ProgramingLangueCheckIdIsExist(int id)
        {
            var result = await _programingLanguesRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException("Program Language Id does not exists.");
        }
        public async Task ProgramingLangueCheckNameIsExist(string name)
        {
            var result = await _programingLanguesRepository.GetAsync(b => b.Name.ToLower() == name.ToLower());
            if (result != null) throw new BusinessException("Program Language Name does exists.");
        }
        public void ProgramingLangueCheckEntityIfEmpty(ProgramingLangues programingLangues)
        {
            if (programingLangues == null) throw new BusinessException("Entity does not exists.");
        }
    }
}
