using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Resource;
using VirtualExpress.Domain.Services;
using AutoMapper;
using VirtualExpress.Domain.Models;
using VirtualExpress.Extensions;

namespace VirtualExpress.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentaryService _commentaryService;
        private readonly IMapper _mapper;

        public CommentController(ICommentaryService commentaryService, IMapper mapper)
        {
            _commentaryService = commentaryService;
            _mapper = mapper;
        }

        [SwaggerResponse(200,"List of commentary",typeof(IEnumerable<CommentaryResource>))]
        [ProducesResponseType(typeof(IEnumerable<CommentaryResource>),200)]
        [HttpGet]
        public async Task<IEnumerable<CommentaryResource>> GetAsync()
        {
            var commentaries = await _commentaryService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Comentary>, IEnumerable<CommentaryResource>>(commentaries);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCommentaryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var commentary = _mapper.Map<SaveCommentaryResource, Comentary>(resource);
            var result = await _commentaryService.SaveAsync(commentary);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var commentaryResource = _mapper.Map<Comentary, CommentaryResource>(result.Resource);
            return Ok(commentaryResource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCommentaryResource resource)
        {
            var commentary = _mapper.Map<SaveCommentaryResource, Comentary>(resource);
            var result = await _commentaryService.UpdateAsync(id,commentary);

            if (result == null)
                return BadRequest(result.Message);

            var commentaryResource = _mapper.Map<Comentary, CommentaryResource>(result.Resource);
            return Ok(commentaryResource);
        }
    }
}
