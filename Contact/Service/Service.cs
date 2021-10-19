using Contact.Model;
using Contact.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Service
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<SPResult> AddAsync<TInput>(TInput entity, string SPName) where TInput : class
        {
            return await _repository.AddAsync(entity, SPName);
        }

        public async Task<SPResult> DeleteAsync<TInput>(TInput entity, string SPName) where TInput : class
        {
            return await _repository.DeleteAsync(entity, SPName);
        }

        public async Task<SPResult<TOutput>> ListAsync<TInput, TOutput>(TInput entity, string SPName)
            where TInput : class
            where TOutput : class
        {
            return await _repository.ListAsync<TInput, TOutput>(entity, SPName);
        }
    }
}
