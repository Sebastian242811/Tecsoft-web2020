using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Domain.Services;
using VirtualExpress.Resource;

namespace VirtualExpress.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/company/{companyId}/terminals")]
    public class CompanyTerminalController : ControllerBase
    {
        private readonly ITerminalService _terminalService;
        private readonly IMapper _mapper;

        public CompanyTerminalController(ITerminalService terminalRepository, IMapper mapper)
        {
            _terminalService = terminalRepository;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all Terminals by Company Id",
            Description = "List of Terminals for a Company",
            OperationId = "ListAllTerminalsByCompany",
            Tags = new[] { "Company" }
        )]
        [SwaggerResponse(200, "List of terminals by CompanyId", typeof(IEnumerable<TerminalResource>))]
        [ProducesResponseType(typeof(IEnumerable<TerminalResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<TerminalResource>> GetTerminalsByCompanyIDAllAsync(int companyId)
        {
            var terminals = await _terminalService.ListByCompanyByIdAsync(companyId);
            var resource = _mapper.Map<IEnumerable<Terminal>, IEnumerable<TerminalResource>>(terminals);
            return resource;
        }


        [SwaggerOperation(
            Summary = "Assign a Terminal to a Company",
            Description = "Assign a Terminal to a Company",
            OperationId = "AssignTerminalToCompany",
            Tags = new[] { "Company" }
        )]
        [SwaggerResponse(200, "List of terminals by CompanyId", typeof(IEnumerable<TerminalResource>))]
        [ProducesResponseType(typeof(IEnumerable<TerminalResource>), 200)]
        [HttpPost]
        public async Task<IActionResult> AssignTerminalCompany(int companyId,int terminalId)
        {
            var result = await _terminalService.AssignTerminalCompanyAsync(terminalId, companyId);
            if (!result.Sucess)
                return BadRequest(result.Message);
            Terminal terminal = _terminalService.GetByIdAsync(terminalId).Result.Resource;
            var resource = _mapper.Map<Terminal, TerminalResource>(terminal);
            return Ok(resource);
           
        }
    }
}
