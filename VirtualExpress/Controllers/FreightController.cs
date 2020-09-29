using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services;
using VirtualExpress.Extensions;
using VirtualExpress.Persistence.Repository;
using VirtualExpress.Resource;

namespace VirtualExpress.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FreightController : ControllerBase
    {
        private readonly IFreightService _freightService;
        private readonly IMapper _mapper;

        public FreightController(IFreightService freightService, IMapper mapper)
        {
            _freightService = freightService;
            _mapper = mapper;
        }

        [SwaggerResponse(200,"List of Freight",typeof(IEnumerable<FreightResource>))]
        [ProducesResponseType(typeof(IEnumerable<FreightResource>),200)]
        [HttpGet]
        public async Task<IEnumerable<FreightResource>> GetAllAsync()
        {
            var freights = await _freightService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Freight>, IEnumerable<FreightResource>>(freights);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveFreightResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var freight = _mapper.Map<SaveFreightResource, Freight>(resource);
            var result = await _freightService.SaveAsync(freight);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var freightResource = _mapper.Map<Freight, FreightResource>(result.Resource);
            return Ok(freightResource);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] SaveFreightResource resource)
        {
            var freight = _mapper.Map<SaveFreightResource, Freight>(resource);
            var result = await _freightService.UpdateAsync(id, freight);

            if (result == null)
                return BadRequest(result.Message);

            var freightResource = _mapper.Map<Freight, FreightResource>(result.Resource);
            return Ok(freightResource);
        }
    }
}
