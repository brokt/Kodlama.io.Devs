﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedia.Dtos
{
    public class CreatedUserSocialMediaDtos
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SocialMediaId { get; set; }
        public string Link { get; set; }
        public string SocialMediaName { get; set; }
    }
}
