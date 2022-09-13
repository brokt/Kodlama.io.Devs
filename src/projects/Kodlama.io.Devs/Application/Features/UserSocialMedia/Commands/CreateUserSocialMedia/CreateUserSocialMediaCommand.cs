using Application.Features.ProgramingTechnology.Rules;
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

namespace Application.Features.UserSocialMedia.Commands.CreateUserSocialMedia
{
    public class CreateUserSocialMediaCommand : IRequest<CreatedUserSocialMediaDtos>
    {
        public string Link { get; set; }
        public int UserId { get; set; }
        public int SocialMediaTypesId { get; set; }

        public class CreateUserSocialMediaCommandHandler : IRequestHandler<CreateUserSocialMediaCommand, CreatedUserSocialMediaDtos>
        {
            private readonly IUserSocialMediasRepository _userSocialMediasRepository;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

            public CreateUserSocialMediaCommandHandler(IUserSocialMediasRepository userSocialMediasRepository, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediasRepository = userSocialMediasRepository;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;

            }
            public async Task<CreatedUserSocialMediaDtos> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _userSocialMediaBusinessRules.UserSocialMediaLinkCanNotBeDuplicatedWhenInserted(request.Link);
                var mappedEntity = request.Adapt<UserSocialMedias>();
                var createdEntity = await _userSocialMediasRepository.AddAsync(mappedEntity);
                return createdEntity.Adapt<CreatedUserSocialMediaDtos>();
            }
        }
    }
}
