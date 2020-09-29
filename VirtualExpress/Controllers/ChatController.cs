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
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatController(IMapper mapper, IChatService chatService)
        {
            _mapper = mapper;
            _chatService = chatService;
        }

        [SwaggerResponse(200, "List of chat", typeof(IEnumerable<ChatResource>))]
        [ProducesResponseType(typeof(IEnumerable<ChatResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<ChatResource>> GetAllAsync()
        {
            var chats = await _chatService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Chat>, IEnumerable<ChatResource>>(chats);

            return resource;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveChatResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var chat = _mapper.Map<SaveChatResource, Chat>(resource);
            // TODO: Implement Response Logic
            var result = await _chatService.SaveAsync(chat);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var chatResource = _mapper.Map<Chat, ChatResource>(result.Resource);

            return Ok(chatResource);
        }


    }
}
