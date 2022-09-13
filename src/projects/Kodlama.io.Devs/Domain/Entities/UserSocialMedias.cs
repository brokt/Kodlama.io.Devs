using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserSocialMedias : Entity
    {
        public UserSocialMedias()
        {

        }

        public UserSocialMedias(int id,int userId, int codeSocialMediaTypesId, string link):this()
        {
            Id = id;
            UserId = userId;
            CodeSocialMediaTypesId = codeSocialMediaTypesId;
            Link = link;
        }

        public int UserId { get; set; }
        public int CodeSocialMediaTypesId { get; set; }        
        public string Link { get; set; }
        public virtual User User { get; set; }
        public virtual CodeSocialMediaTypes CodeSocialMediaTypes { get; set; }
    }
}
