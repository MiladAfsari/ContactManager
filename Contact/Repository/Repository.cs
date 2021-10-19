using Contact.Data;
using Contact.Model;
using Contact.Repository.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository
{
    public class Repository : IRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SPResult> AddAsync<TInput>(TInput entity, string SPName) where TInput : class
        {
            try
            {
                var param = new DynamicParameters();

                var propertyList = entity.GetType().GetProperties();
                foreach (var item in propertyList) param.Add(item.Name, item.GetValue(entity, null));
                param.Add("ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("ErrorMessage", dbType: DbType.String, size: 250, direction: ParameterDirection.Output);
                await _unitOfWork.Connection.ExecuteAsync(SPName, param, commandType: CommandType.StoredProcedure);
                return new SPResult
                {
                    ErrorCode = param.Get<int>("ErrorCode"),
                    ErrorMessage = param.Get<string>("ErrorMessage"),
                };
            }
            catch (Exception ex)
            {
                return new SPResult
                {
                    ErrorCode = -1,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<SPResult> DeleteAsync<TInput>(TInput entity, string SPName) where TInput : class
        {
            try
            {
                var param = new DynamicParameters(entity);
                param.AddDynamicParams(entity);
                param.Add("ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("ErrorMessage", dbType: DbType.String, size: 250, direction: ParameterDirection.Output);
                await _unitOfWork.Connection.ExecuteAsync(SPName, param, commandType: CommandType.StoredProcedure);
                return new SPResult
                {

                    ErrorCode = param.Get<int>("ErrorCode"),
                    ErrorMessage = param.Get<string>("ErrorMessage"),
                };
            }
            catch (Exception ex)
            {
                return new SPResult
                {
                    ErrorCode = -1,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<SPResult<TOutput>> ListAsync<TInput, TOutput>(TInput entity, string SPName)
            where TInput : class
            where TOutput : class
        {
            try
            {
                var param = new DynamicParameters(entity);
                param.Add("ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("ErrorMessage", dbType: DbType.String, size: 250, direction: ParameterDirection.Output);
                var result = await _unitOfWork.Connection.QueryAsync<TOutput>(SPName, param,
                      commandType: CommandType.StoredProcedure);
                return new SPResult<TOutput>
                {
                    ErrorCode = param.Get<int>("ErrorCode"),
                    ErrorMessage = param.Get<string>("ErrorMessage"),
                    List = result
                };
            }
            catch (Exception ex)
            {

                return new SPResult<TOutput>
                {
                    ErrorCode = -1,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
