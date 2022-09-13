using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedia.Rules
{
    public class UserSocialMediaBusinessRules
    {
        private readonly IUserSocialMediasRepository _userSocialMediasRepository;

        public UserSocialMediaBusinessRules(IUserSocialMediasRepository userSocialMediasRepository)
        {
            _userSocialMediasRepository = userSocialMediasRepository;
        }

        public async Task UserSocialMediaLinkCanNotBeDuplicatedWhenInserted(string link)
        {
            IPaginate<UserSocialMedias> result = await _userSocialMediasRepository.GetListAsync(b => b.Link.ToLower() == link.ToLower());
            if (result.Items.Any()) throw new BusinessException("Social Media Link is exists.");
        }
        public async Task UserSocialMediaCheckIdIsExist(int id)
        {
            var result = await _userSocialMediasRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException("Social Media Id does not exists.");
        }
        public async Task UserSocialMediaCheckLinkIsExist(string link)
        {
            var result = await _userSocialMediasRepository.GetAsync(b => b.Link.ToLower() == link.ToLower());
            if (result != null) throw new BusinessException("Social Media Name does exists.");
        }
        public async Task UserSocialMediaCheckEntityIfEmpty(UserSocialMedias entity)
        {
            var result = await _userSocialMediasRepository.GetAsync(b => b.Id == entity.Id);
            if (result == null) throw new BusinessException("Entity does not exists.");
        }
        public void UserSocialMediaShouldExistWhenRequested(UserSocialMedias entity)
        {
            if (entity == null) throw new BusinessException("Entity does not exists.");
        }
    }
}
