using Application.Features.ProgramingTechnology.Dtos;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingTechnology.Profiles
{
    public class MappingProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProgramingTechnologies, ProgrammingTechnologyListDtos>().Map(dest => dest.LanguageName, src => src.ProgramingLangues.Name);
            config.NewConfig<ProgramingTechnologies, ProgramingTechnologyGetByIdDtos>().Map(dest => dest.LanguageName, src => src.ProgramingLangues.Name);
        }
    }
}
