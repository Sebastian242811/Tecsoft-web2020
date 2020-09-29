using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services;
using VirtualExpress.Extensions;
using VirtualExpress.Resource;

namespace VirtualExpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public DriverController(IMapper mapper, IDriverService driverService)
        {
            _mapper = mapper;
            _driverService = driverService;
        }

        [SwaggerResponse(200, "List of Drivers", typeof(IEnumerable<DriverResource>))]
        [ProducesResponseType(typeof(IEnumerable<DriverResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<DriverResource>> GetAllAsync()
        {
            var driver = await _driverService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverResource>>(driver);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDriverResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var driver = _mapper.Map<SaveDriverResource, Driver>(resource);
            // TODO: Implement Response Logic
            var result = await _driverService.SaveAsync(driver);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var driverResource = _mapper.Map<Driver, DriverResource>(result.Resource);

            return Ok(driverResource);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDriverResource resource)
        {
            var driver = _mapper.Map<SaveDriverResource, Driver>(resource);
            var result = await _driverService.UpdateAsync(id, driver);

            if (result == null)
                return BadRequest(result.Message);

            var driverResource = _mapper.Map<Driver, DriverResource>(result.Resource);
            return Ok(driverResource);
        }
    }
}
