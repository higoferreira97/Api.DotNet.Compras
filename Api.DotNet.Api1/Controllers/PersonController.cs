using Api.DotNet.App.DTOs;
using Api.DotNet.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.DotNet.Api1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);


        }
    }
}
