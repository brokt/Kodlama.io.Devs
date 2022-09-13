using Application.Features.Auths.Dtos;
using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Auths.Querires.LoginUser
{
    public class LoginUserQuery : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AccessToken>
        {
            private readonly IUsersRepository _usersRepository;
            private readonly UserBusinessRules _userBusinessRules;
            private ITokenHelper _tokenHelper;

            public LoginUserQueryHandler(IUsersRepository usersRepository, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper)
            {
                _usersRepository = usersRepository;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                var user = await _usersRepository.GetAsync(u => u.Email == request.Email && u.Status,m => m.Include(i => i.UserOperationClaims).ThenInclude(ti => ti.OperationClaim));

                _userBusinessRules.UserShouldExistWhenRequested(user);  
                _userBusinessRules.VerifyUserPasswordHash(request.Password,user.PasswordSalt,user.PasswordHash);

                var accessToken = _tokenHelper.CreateToken(user,user.UserOperationClaims.Select(x => x.OperationClaim).ToList());

                return accessToken;
            }
        }
    }
}
