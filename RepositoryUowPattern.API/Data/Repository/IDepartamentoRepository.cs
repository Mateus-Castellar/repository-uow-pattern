﻿using RepositoryUowPattern.API.Models;

namespace RepositoryUowPattern.API.Data.Repository
{
    public interface IDepartamentoRepository
    {
        Task<Departamento> GetByIdAsync(int id);
        void Add(Departamento departamento);
        bool Save();
    }
}