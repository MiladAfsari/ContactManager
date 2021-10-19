using Contact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Service
{
    public interface IService
    {
        Task<SPResult<TOutput>> ListAsync<TInput, TOutput>(TInput entity, string SPName) where TInput : class where TOutput : class;
        Task<SPResult> AddAsync<TInput>(TInput entity, string SPName) where TInput : class;
        Task<SPResult> DeleteAsync<TInput>(TInput entity, string SPName) where TInput : class;
    }
}
