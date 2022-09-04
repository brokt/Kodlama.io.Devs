using Application.Features.ProgramingLangue.Commands.CreateProgramingLangue;
using Application.Features.ProgramingLangue.Commands.DeleteProgramingLangue;
using Application.Features.ProgramingLangue.Commands.UpdateProgramingLangue;
using Application.Features.ProgramingLangue.Dtos;
using Application.Features.ProgramingLangue.Queries.GetByIdProgramingLanguage;
using Application.Features.ProgramingLangue.Queries.GetListProgramingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLangueCommand createProgramingLangueCommand)
        {
            var result = await Mediator.Send(createProgramingLangueCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProgramingLangueCommand updateProgramingLangueCommand)
        {
            var result = await Mediator.Send(updateProgramingLangueCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProgramingLangueCommand deleteProgramingLangueCommand)
        {
            var result = await Mediator.Send(deleteProgramingLangueCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery getByIdProgramingLanguageQuery)
        {
            var result = await Mediator.Send(getByIdProgramingLanguageQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListProgramingLanguageQuery getListProgramingLanguageQuery)
        {
            var result = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(result);
        }
    }
}
