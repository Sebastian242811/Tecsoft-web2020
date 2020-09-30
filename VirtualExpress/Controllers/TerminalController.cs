using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services;
using VirtualExpress.Extensions;
using VirtualExpress.Resource;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualExpress.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TerminalController : ControllerBase
    {
        private readonly ITerminalService _terminalService;
        private readonly IMapper _mapper;

        public TerminalController(ITerminalService terminalService, IMapper mapper)
        {
            _terminalService = terminalService;
            _mapper = mapper;
        }


        [SwaggerResponse(200,"List of terminals",typeof(IEnumerable<TerminalResource>))]
        [ProducesResponseType(typeof(IEnumerable<TerminalResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<TerminalResource>> GetAllAsync()
        {
            var terminals = await _terminalService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Terminal>, IEnumerable<TerminalResource>>(terminals);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTerminalResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var terminal = _mapper.Map<SaveTerminalResource, Terminal>(resource);
            var result = await _terminalService.SaveAssync(terminal);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var terminalResource = _mapper.Map<Terminal, TerminalResource>(result.Resource);

            return Ok(terminalResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTerminalResource resource)
        {
            var terminal = _mapper.Map<SaveTerminalResource,Terminal>(resource);
            var result = await _terminalService.UpdateAssync(id,terminal);

            if (result == null)
                return BadRequest(result.Message);

            var terminalresource = _mapper.Map<Terminal, TerminalResource>(result.Resource);
            return Ok(terminalresource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _terminalService.DeleteAsync(id);

            if (!result.Sucess)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

    }
}
