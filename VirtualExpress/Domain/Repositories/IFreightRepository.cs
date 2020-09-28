﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface IFreightRepository
    {
        Task<IEnumerable<Freight>> ListAsync();
        Task AddAsync(Freight Freight);
        Task<Freight> FindById(int id);
        void Update(Freight Freight);
        void Remove(Freight Freight);
    }
}
