using Application.Features.UserSocialMedia.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedia.Commands.DeleteUserSocialMedia;
using Application.Features.UserSocialMedia.Commands.UpdateUserSocialMedia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UserSocialMediaController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserSocialMediaCommand createUserSocialMediaCommand)
        {
            var result = await Mediator.Send(createUserSocialMediaCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserSocialMediaCommand updateUserSocialMediaCommand)
        {
            var result = await Mediator.Send(updateUserSocialMediaCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserSocialMediaCommand deleteUserSocialMediaCommand)
        {
            var result = await Mediator.Send(deleteUserSocialMediaCommand);
            return Ok(result);
        }
    }
}
