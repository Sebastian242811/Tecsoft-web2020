using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
    public class PackageController : ControllerBase
    {
        private readonly IPackageStateService _packageStateService;
        private readonly IMapper _mapper;

        public PackageController(IPackageStateService packageStateService, IMapper mapper)
        {
            _packageStateService = packageStateService;
            _mapper = mapper;
        }

        [SwaggerResponse(200, "List of package", typeof(IEnumerable<PackageResource>))]
        [ProducesResponseType(typeof(IEnumerable<PackageResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<PackageResource>> GetAllAsync()
        {
            var packages = await _packageStateService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Package>, IEnumerable<PackageResource>>(packages);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePackageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var package = _mapper.Map<SavePackageResource, Package>(resource);
            var result = await _packageStateService.SaveAsync(package);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var packageResource = _mapper.Map<Package, PackageResource>(result.Resource);

            return Ok(packageResource);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsyng(int id, [FromBody] SavePackageResource resource)
        {
            var package = _mapper.Map<SavePackageResource, Package>(resource);
            var result = await _packageStateService.UpdateAsync(id, package);

            if (result == null)
                return BadRequest(result.Message);

            var packageResource = _mapper.Map<Package, PackageResource>(result.Resource);

            return Ok(packageResource);
        }
    }
}
