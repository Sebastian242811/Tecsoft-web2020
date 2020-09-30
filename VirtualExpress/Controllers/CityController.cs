using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services;
using VirtualExpress.Domain.Services.Communications;
using VirtualExpress.Extensions;
using VirtualExpress.Resource;

namespace VirtualExpress.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        //[SwaggerOperation(
        //    Summary = "List all company",
        //    Description = "List of company",
        //    OperationId = "ListAllCompany",
        //    Tags = new[] { "List", "Company" }
        //    )]

        [SwaggerResponse(200, "List of City", typeof(IEnumerable<CityResource>))]
        [ProducesResponseType(typeof(IEnumerable<CityResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAllAsync()
        {
            var cities = await _cityService.ListAsync();
            var resource = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(cities);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCityResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var city = _mapper.Map<SaveCityResource, City>(resource);
            // TODO: Implement Response Logic
            var result = await _cityService.SaveAsynnc(city);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var cityResource = _mapper.Map<City, CityResource>(result.Resource);

            return Ok(cityResource);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCityResource resource)
        {
            var city = _mapper.Map<SaveCityResource, City>(resource);
            var result = await _cityService.UpdateAsync(id, city);

            if (result == null)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<City, CityResource>(result.Resource);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cityService.DeleteAsync(id);

            if (!result.Sucess)
                return BadRequest(result.Message);

            return Ok("Delete");
        }
    }
}
