using Application.Features.ProgramingTechnology.Commands.CreateProgramingTechnology;
using Application.Features.ProgramingTechnology.Commands.DeleteProgramingTechnology;
using Application.Features.ProgramingTechnology.Commands.UpdateProgramingTechnology;
using Application.Features.ProgramingTechnology.Queries.GetByIdProgramingTechnology;
using Application.Features.ProgramingTechnology.Queries.GetListProgramingTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PrograminTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingTechnologyCommand createProgramingTechnologyCommand)
        {
            var result = await Mediator.Send(createProgramingTechnologyCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProgramingTechnologyCommand updateProgramingTechnologyCommand)
        {
            var result = await Mediator.Send(updateProgramingTechnologyCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProgramingTechnologyCommand deleteProgramingTechnologyCommand)
        {
            var result = await Mediator.Send(deleteProgramingTechnologyCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingTechnologyQuery getByIdProgramingTechnologyQuery)
        {
            var result = await Mediator.Send(getByIdProgramingTechnologyQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListProgramingTechnologyQuery getListProgramingTechnologyQuery)
        {
            var result = await Mediator.Send(getListProgramingTechnologyQuery);
            return Ok(result);
        }
    }
}
