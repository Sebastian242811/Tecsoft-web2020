using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;
using VirtualExpress.Extensions;
using VirtualExpress.Resource;

namespace VirtualExpress.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        //[SwaggerOperation(
        //    Summary = "List all company",
        //    Description = "List of company",
        //    OperationId = "ListAllCompany",
        //    Tags = new[] { "List", "Company" }
        //    )]

        [SwaggerResponse(200, "List of Company", typeof(IEnumerable<CompanyResource>))]
        [ProducesResponseType(typeof(IEnumerable<CompanyResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<CompanyResource>> GetAllAsync()
        {
            var companies = await _companyService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            // TODO: Implement Response Logic
            var result = await _companyService.SaveAsync(company);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);

            return Ok(companyResource);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompanyResource resource)
        {
            var category = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _companyService.UpdateAsync(id, category);

            if (result == null)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}
