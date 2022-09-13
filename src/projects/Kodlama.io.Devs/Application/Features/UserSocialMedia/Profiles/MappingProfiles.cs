using Application.Features.UserSocialMedia.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedia.Commands.UpdateUserSocialMedia;
using Application.Features.UserSocialMedia.Dtos;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedia.Profiles
{
    public class MappingProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserSocialMedias, CreatedUserSocialMediaDtos>()
                .Map(dest => dest.SocialMediaName, src => src.CodeSocialMediaTypes.Name)
                .Map(dest => dest.SocialMediaId,src => src.CodeSocialMediaTypesId);
            
            config.NewConfig<CreatedUserSocialMediaDtos, UserSocialMedias >()
                .Map(dest => dest.CodeSocialMediaTypesId, src => src.SocialMediaId);
            
            config.NewConfig<CreateUserSocialMediaCommand, UserSocialMedias>()
                .Map(dest => dest.CodeSocialMediaTypesId, src => src.SocialMediaTypesId);
            
            config.NewConfig<UpdateUserSocialMediaCommand, UserSocialMedias>()
                .Map(dest => dest.CodeSocialMediaTypesId, src => src.SocialMediaTypesId);


            config.NewConfig<UserSocialMedias, UpdatedSocialMediaDtos>()
                .Map(dest => dest.SocialMediaName, src => src.CodeSocialMediaTypes.Name)
                .Map(dest => dest.SocialMediaId, src => src.CodeSocialMediaTypesId); 
            
            config.NewConfig<UpdatedSocialMediaDtos, UserSocialMedias >()
                .Map(dest => dest.CodeSocialMediaTypesId, src => src.SocialMediaId);
        }
    }
}
