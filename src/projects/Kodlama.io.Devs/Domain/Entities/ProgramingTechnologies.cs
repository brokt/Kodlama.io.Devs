using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgramingTechnologies : Entity
    {
        public string Name { get; set; }
        public int ProgramingLanguesId { get; set; }
        public virtual ProgramingLangues? ProgramingLangues { get; set; }

        public ProgramingTechnologies()
        {
        }
        public ProgramingTechnologies(int id, string name,int programingLanguesId) : this()
        {
            Id = id;
            Name = name;
            ProgramingLanguesId = programingLanguesId;
        }
    }
}
