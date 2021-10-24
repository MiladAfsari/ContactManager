using Contact.Model;
using Contact.Repository;
using Contact.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Service
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork ;
        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SPResult> AddAsync<TInput>(TInput entity, string SPName) where TInput : class
        {
            var result =  await _unitOfWork.repository.AddAsync(entity, SPName);
            _unitOfWork.Commit();
            return result;

        }

        public async Task<SPResult> DeleteAsync<TInput>(TInput entity, string SPName) where TInput : class
        {
            var result = await _unitOfWork.repository.DeleteAsync(entity, SPName);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<SPResult<TOutput>> ListAsync<TInput, TOutput>(TInput entity, string SPName)
            where TInput : class
            where TOutput : class
        {
            return await _unitOfWork.repository.ListAsync<TInput, TOutput>(entity, SPName);
        }
    }
}
