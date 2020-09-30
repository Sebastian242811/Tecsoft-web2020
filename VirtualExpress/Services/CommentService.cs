using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Domain.Services;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Services
{
    public class CommentService : ICommentaryService
    {
        private readonly IComentaryRepository _comentaryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IComentaryRepository comentaryRepository, IUnitOfWork unitOfWork)
        {
            _comentaryRepository = comentaryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommentaryResponse> DeleteAsync(int id)
        {
            var existing = await _comentaryRepository.FindById(id);
            if (existing == null)
                return new CommentaryResponse("Commentary not found");

            try
            {
                _comentaryRepository.Remove(existing);
                await _unitOfWork.CompleteAsync();

                return new CommentaryResponse(existing);
            }
            catch(Exception e)
            {
                return new CommentaryResponse($"An error ocurred while deleting the Commentary: {e.Message}");
            }
        }

        public async Task<CommentaryResponse> GetById(int id)
        {
            var existing = await _comentaryRepository.FindById(id);
            if (existing == null)
                return new CommentaryResponse("Commentary not found");
            return new CommentaryResponse(existing);
        }

        public async Task<IEnumerable<Comentary>> ListAsync()
        {
            return await _comentaryRepository.ListAsync();
        }

        public async Task<CommentaryResponse> SaveAsync(Comentary comentary)
        {
            try
            {
                await _comentaryRepository.AddAsync(comentary);
                await _unitOfWork.CompleteAsync();

                return new CommentaryResponse(comentary);
            }
            catch (Exception e)
            {
                return new CommentaryResponse($"An error ocurred while saving the Commentary: {e.Message}");
            }
        }

        public async Task<CommentaryResponse> UpdateAsync(int id, Comentary comentary)
        {
            var existing = await _comentaryRepository.FindById(id);
            if (existing == null)
                return new CommentaryResponse("Commentary not found");
            existing.Opinion = comentary.Opinion;
            try
            {
                _comentaryRepository.Update(existing);
                await _unitOfWork.CompleteAsync();

                return new CommentaryResponse(existing);
            }
            catch (Exception e)
            {
                return new CommentaryResponse($"An error ocurred while updating the Commentary: {e.Message}");
            }
        }
    }
}
