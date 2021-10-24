using Contact.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository repository { get; }
        void Commit();
    }
}
