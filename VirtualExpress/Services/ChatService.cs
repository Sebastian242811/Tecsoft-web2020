using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Domain.Services;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChatService(IChatRepository chatRepository, IUnitOfWork unitOfWork)
        {
            _chatRepository = chatRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ChatResponse> DeleteAsync(int id)
        {
            var existingChat = await _chatRepository.FindById(id);
            if (existingChat == null)
                return new ChatResponse("Chat not found");
            try
            {
                _chatRepository.Remove(existingChat);
                await _unitOfWork.CompleteAsync();

                return new ChatResponse(existingChat);
            }
            catch(Exception e)
            {
                return new ChatResponse($"An error ocurred while deleting the Chat: {e.Message}");
            }
        }

        public async Task<ChatResponse> GetById(int id)
        {
            var existingChat = await _chatRepository.FindById(id);
            if (existingChat == null)
                return new ChatResponse("Chat not found");
            return new ChatResponse(existingChat);
        }
   
        public async Task<IEnumerable<Chat>> ListAsync()
        {
            return await _chatRepository.ListAsync();
        }

        public async Task<IEnumerable<Chat>> ListByUserIdAndEmployeeId(int userId, int employeeId)
        {
            return await _chatRepository.ListByUserIdAndEmployeeId(userId, employeeId);
        }

        public async Task<ChatResponse> SaveAsync(Chat chat)
        {
            try
            {
                await _chatRepository.AddAsync(chat);
                await _unitOfWork.CompleteAsync();

                return new ChatResponse(chat);
            }
            catch (Exception e)
            {
                return new ChatResponse($"An error ocurred while saving the Chat: {e.Message}");
            }
        }

        public async Task<ChatResponse> UpdateAsync(int id, Chat chat)
        {
            var existingChat = await _chatRepository.FindById(id);
            if (existingChat == null)
                return new ChatResponse("Chat not found");
            existingChat.message = chat.message;
            try
            {
                _chatRepository.Remove(existingChat);
                await _unitOfWork.CompleteAsync();

                return new ChatResponse(existingChat);
            }
            catch (Exception e)
            {
                return new ChatResponse($"An error ocurred while updating the Chat: {e.Message}");
            }
        }
    }
}
