using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgramingLangues : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<ProgramingTechnologies> ProgramingTechnologies { get; set; }
        public ProgramingLangues()
        {
        }
        public ProgramingLangues(int id,string name) : this()
        {
            Id = id;    
            Name = name;
        }
    }
}
