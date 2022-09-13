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

namespace Application.Features.UserSocialMedia.Commands.DeleteUserSocialMedia
{
    public class DeleteUserSocialMediaCommand : IRequest<DeletedUserSocialMediaDtos>
    {
        public int Id { get; set; }

        public class DeleteUserSocialMediaCommandHandler : IRequestHandler<DeleteUserSocialMediaCommand, DeletedUserSocialMediaDtos>
        {
            private readonly IUserSocialMediasRepository _userSocialMediasRepository;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

            public DeleteUserSocialMediaCommandHandler(IUserSocialMediasRepository userSocialMediasRepository, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediasRepository = userSocialMediasRepository;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;

            }
            public async Task<DeletedUserSocialMediaDtos> Handle(DeleteUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var socialMediaEntity = await _userSocialMediasRepository.GetAsync(g => g.Id == request.Id);
                _userSocialMediaBusinessRules.UserSocialMediaShouldExistWhenRequested(socialMediaEntity);
                var deletedEntity = await _userSocialMediasRepository.DeleteAsync(socialMediaEntity);
                return deletedEntity.Adapt<DeletedUserSocialMediaDtos>();
            }
        }
    }
}
