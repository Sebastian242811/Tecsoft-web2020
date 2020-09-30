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
    public class DispatcherController : ControllerBase
    {
        private readonly IDispatcherService _dispatcherService;
        private readonly IMapper _mapper;

        public DispatcherController(IMapper mapper, IDispatcherService dispatcherService)
        {
            _mapper = mapper;
            _dispatcherService = dispatcherService;
        }


        [SwaggerResponse(200, "List of Dispatchers", typeof(IEnumerable<DispatcherResource>))]
        [ProducesResponseType(typeof(IEnumerable<DispatcherResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<DispatcherResource>> GetAllAsync()
        {
            var dispatcher = await _dispatcherService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Dispatcher>, IEnumerable<DispatcherResource>>(dispatcher);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDispatcherResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var dispatcher = _mapper.Map<SaveDispatcherResource, Dispatcher>(resource);
            // TODO: Implement Response Logic
            var result = await _dispatcherService.SaveAsync(dispatcher);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var dispatcherResource = _mapper.Map<Dispatcher, DispatcherResource>(result.Resource);

            return Ok(dispatcherResource);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDispatcherResource resource)
        {
            var dispatcher = _mapper.Map<SaveDispatcherResource, Dispatcher>(resource);
            var result = await _dispatcherService.UpdateAsync(id, dispatcher);

            if (result == null)
                return BadRequest(result.Message);

            var dispatcherResource = _mapper.Map<Dispatcher, DispatcherResource>(result.Resource);
            return Ok(dispatcherResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _dispatcherService.DeleteAsync(id);

            if (!result.Sucess)
                return BadRequest(result.Message);

            return Ok("Delete");
        }
    }
}
