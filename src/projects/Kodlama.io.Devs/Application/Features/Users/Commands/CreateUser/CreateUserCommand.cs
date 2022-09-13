using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreatedUserDtos>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDtos>
        {
            private readonly IUsersRepository _usersRepository;
            private readonly UserBusinessRules _userBusinessRules;

            public CreateUserCommandHandler(IUsersRepository usersRepository, UserBusinessRules userBusinessRules)
            {
                _usersRepository = usersRepository;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<CreatedUserDtos> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
               var userEntity =  await _usersRepository.GetAsync(a => a.Status == true && a.Email == request.Email);
                _userBusinessRules.UserShouldExistWhenRequested(userEntity);
                await _userBusinessRules.UserCanNotBeDuplicatedWhenInserted(request.Email);

                HashingHelper.CreatePasswordHash(request.Password, out var passwordSalt, out var passwordHash);
                var user = new User
                {
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                var createdEntity = await _usersRepository.AddAsync(user);
                return createdEntity.Adapt<CreatedUserDtos>();
            }
        }
    }
}
