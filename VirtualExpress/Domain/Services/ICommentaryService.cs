using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Domain.Services
{
    public interface ICommentaryService
    {
        Task<IEnumerable<Comentary>> ListAsync();
        Task<CommentaryResponse> SaveAsync(Comentary comentary);
        Task<CommentaryResponse> GetById(int id);
        Task<CommentaryResponse> UpdateAsync(int id, Comentary comentary);
        Task<CommentaryResponse> DeleteAsync(int id);
    }
}
