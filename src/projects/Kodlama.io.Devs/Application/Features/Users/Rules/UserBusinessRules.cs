using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUsersRepository _usersRepository;

        public UserBusinessRules(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task UserCanNotBeDuplicatedWhenInserted(string email)
        {
            IPaginate<User> result = await _usersRepository.GetListAsync(u => u.Email == email);
            if (result.Items.Any()) throw new BusinessException("User email exists.");
        }

        public void UserShouldExistWhenRequested(User user)
        {
            if (user == null) throw new BusinessException("Requested user does not exist.");
        } 
        public void UserShouldNotExistWhenRequested(User user)
        {
            if (user != null) throw new BusinessException("Requested user does not exist.");
        }

        public void VerifyUserPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException("Password is not correct.");
        }
    }
}
