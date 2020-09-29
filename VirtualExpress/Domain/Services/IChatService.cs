using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;
using VirtualExpress.Persistence.Repository;

namespace VirtualExpress.Domain.Services
{
    public interface IChatService
    {
        Task<IEnumerable<Chat>> ListAsync();
        Task<IEnumerable<Chat>> ListByUserIdAndEmployeeId(int userId,int employeeId);
        Task<ChatResponse> GetById(int id);
        Task<ChatResponse> SaveAsync(Chat chat);
        Task<ChatResponse> UpdateAsync(int id, Chat chat);
        Task<ChatResponse> DeleteAsync(int id);
    }
}
