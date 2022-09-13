using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingTechnology.Rules
{
    public class ProgramingTechnologyBusinessRules
    {
        private readonly IProgramingTechnologiesRepository _programingTechnologysRepository;

        public ProgramingTechnologyBusinessRules(IProgramingTechnologiesRepository programingTechnologyRepository)
        {
            _programingTechnologysRepository = programingTechnologyRepository;
        }

        public async Task ProgramingTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingTechnologies> result = await _programingTechnologysRepository.GetListAsync(b => b.Name.ToLower() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException("Programing Technology name is exists.");
        }
        public async Task ProgramingTechnologyCheckIdIsExist(int id)
        {
            var result = await _programingTechnologysRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException("Program Technology Id does not exists.");
        }
        public async Task ProgramingTechnologyCheckNameIsExist(string name)
        {
            var result = await _programingTechnologysRepository.GetAsync(b => b.Name.ToLower() == name.ToLower());
            if (result != null) throw new BusinessException("Program Technology Name does exists.");
        }
        public async Task ProgramingTechnologyCheckEntityIfEmpty(ProgramingTechnologies entity)
        {
            var result = await _programingTechnologysRepository.GetAsync(b => b.Id == entity.Id);
            if (result == null) throw new BusinessException("Entity does not exists.");
        }
        public void ProgramingTechnologyShouldExistWhenRequested(ProgramingTechnologies entity)
        {
            if (entity == null) throw new BusinessException("Entity does not exists.");
        }
    }
}
