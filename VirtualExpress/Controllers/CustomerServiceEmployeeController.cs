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
    public class CustomerServiceEmployeeController : ControllerBase
    {
        private readonly ICustomerServiceEmployeeService _customerEmployeeService;
        private readonly IMapper _mapper;

        public CustomerServiceEmployeeController(IMapper mapper, ICustomerServiceEmployeeService customeremployeeService)
        {
            _mapper = mapper;
            _customerEmployeeService = customeremployeeService;
        }

        [SwaggerResponse(200, "List of Customer Service Employees", typeof(IEnumerable<CustomerServiceEmployeeResource>))]
        [ProducesResponseType(typeof(IEnumerable<CustomerServiceEmployeeResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<CustomerServiceEmployeeResource>> GetAllAsync()
        {
            var employees = await _customerEmployeeService.ListAsync();
            var resource = _mapper.Map<IEnumerable<CustomerServiceEmployee>, IEnumerable<CustomerServiceEmployeeResource>>(employees);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomerServiceEmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveCustomerServiceEmployeeResource, CustomerServiceEmployee>(resource);
            // TODO: Implement Response Logic
            var result = await _customerEmployeeService.SaveAsync(employee);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<CustomerServiceEmployee, CustomerServiceEmployeeResource>(result.Resource);

            return Ok(employeeResource);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCustomerServiceEmployeeResource resource)
        {
            var employee = _mapper.Map<SaveCustomerServiceEmployeeResource, CustomerServiceEmployee>(resource);
            var result = await _customerEmployeeService.UpdateAsync(id, employee);

            if (result == null)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<CustomerServiceEmployee, CustomerServiceEmployeeResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerEmployeeService.DeleteAsync(id);

            if (!result.Sucess)
                return BadRequest(result.Message);

            return Ok("Delete");
        }
    }
}
