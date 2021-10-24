using Contact.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Repository.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbTransaction _dbTransaction;
        public UnitOfWork(IDbTransaction dbTransaction,IRepository genericRepository)
        {
            _dbTransaction = dbTransaction;
            repository = genericRepository;
        }

        public IRepository repository { get; }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {

                _dbTransaction.Rollback();
            }
        }


        public void Dispose()
        {
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}
