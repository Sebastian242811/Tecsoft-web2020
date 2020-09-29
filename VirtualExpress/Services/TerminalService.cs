﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Domain.Services;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Services
{
    public class TerminalService : ITerminalService
    {
        private readonly ITerminalRepository _terminalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TerminalService(ITerminalRepository terminalRepository, IUnitOfWork unitOfWork)
        {
            _terminalRepository = terminalRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TerminalResponse> DeleteAsync(int id)
        {
            var existingTerminal = await _terminalRepository.FindById(id);
            if (existingTerminal == null)
                return new TerminalResponse("Terminal not found");
            try
            {
                _terminalRepository.Remove(existingTerminal);
                await _unitOfWork.CompleteAsync();

                return new TerminalResponse(existingTerminal);
            }
            catch(Exception e)
            {
                return new TerminalResponse($"An error ocurred while deleting the terminal: {e.Message}");
            }
        }

        public async Task<IEnumerable<Terminal>> ListAsync()
        {
            return await _terminalRepository.ListAsync();
        }

        public Task<IEnumerable<Terminal>> ListByCityOriginIdAndCityShipIdAsync(int cityOriginId, int cityShipId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Terminal>> ListByCompanyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TerminalResponse> SaveAssync(Terminal terminal)
        {
            try
            {
                await _terminalRepository.AddAsync(terminal);
                await _unitOfWork.CompleteAsync();

                return new TerminalResponse(terminal);
            }
            catch(Exception e)
            {
                return new TerminalResponse($"An error ocurred while saving the terminal: {e.Message}");
            }
            
        }

        public Task<TerminalResponse> UpdateAssync(int id, Terminal terminal)
        {
            throw new NotImplementedException();
        }
    }
}
