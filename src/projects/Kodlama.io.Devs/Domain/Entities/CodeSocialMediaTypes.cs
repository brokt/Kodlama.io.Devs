using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CodeSocialMediaTypes : Entity
    {
        public string Name { get; set; }
        public bool InUse { get; set; }
        public int Order { get; set; }

        public virtual ICollection<UserSocialMedias> UserSocialMedias { get; set; }
        public CodeSocialMediaTypes()
        {

        }

        public CodeSocialMediaTypes(int id, string name, bool ınUse, int order):this()
        {
            Id = id;
            Name = name;
            InUse = ınUse;
            Order = order;
        }
    }
}
