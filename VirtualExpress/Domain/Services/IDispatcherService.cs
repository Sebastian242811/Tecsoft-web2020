﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Domain.Services
{
    public interface IDispatcherService
    {
        Task<IEnumerable<Dispatcher>> ListAsync();
        Task<DispatcherResponse> GetById(int id);
        Task<DispatcherResponse> SaveAsync(Dispatcher dispatcher);
        Task<DispatcherResponse> DeleteAsync(int id);
        Task<DispatcherResponse> UpdateAsync(int id, Dispatcher dispatcher);
    }
}
