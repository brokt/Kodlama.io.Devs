using Application.Features.UserSocialMedia.Dtos;
using Application.Features.UserSocialMedia.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedia.Commands.UpdateUserSocialMedia
{
    public class UpdateUserSocialMediaCommand : IRequest<UpdatedSocialMediaDtos>
    {
        public string Link { get; set; }
        public int UserId { get; set; }
        public int SocialMediaTypesId { get; set; }

        public class UpdateUserSocialMediaCommandHandler : IRequestHandler<UpdateUserSocialMediaCommand, UpdatedSocialMediaDtos>
        {
            private readonly IUserSocialMediasRepository _userSocialMediasRepository;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

            public UpdateUserSocialMediaCommandHandler(IUserSocialMediasRepository userSocialMediasRepository, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediasRepository = userSocialMediasRepository;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;

            }
            public async Task<UpdatedSocialMediaDtos> Handle(UpdateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var entity = request.Adapt<UserSocialMedias>();
                await _userSocialMediaBusinessRules.UserSocialMediaCheckEntityIfEmpty(entity);
                await _userSocialMediaBusinessRules.UserSocialMediaCheckLinkIsExist(entity.Link);
                var updatedProgramTechnologyEntity = await _userSocialMediasRepository.UpdateAsync(entity);
                return updatedProgramTechnologyEntity.Adapt<UpdatedSocialMediaDtos>();
            }
        }
    }
}
