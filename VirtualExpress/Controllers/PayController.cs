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
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PayController : ControllerBase
    {
        private readonly IPayService _payService;
        private readonly IMapper _mapper;

        public PayController(IPayService payService, IMapper mapper)
        {
            _payService = payService;
            _mapper = mapper;
        }

        [SwaggerResponse(200,"List of pay",typeof(IEnumerable<PayResource>))]
        [ProducesResponseType(typeof(IEnumerable<PayResource>),200)]
        [HttpGet]
        public async Task<IEnumerable<PayResource>> GetAllAsync()
        {
            var packages = await _payService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Pay>, IEnumerable<PayResource>>(packages);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePayResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var pay = _mapper.Map<SavePayResource, Pay>(resource);
            var result = await _payService.SaveAsync(pay);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var payResource = _mapper.Map<Pay, PayResource>(result.Resource);
            return Ok(payResource);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePayResource resource)
        {
            var pay = _mapper.Map<SavePayResource, Pay>(resource);
            var result = await _payService.UpdateAsync(id, pay);

            if (result == null)
                return BadRequest(result.Message);

            var payResource = _mapper.Map<Pay, PayResource>(result.Resource);
            return Ok(payResource);
        }
    }
}
