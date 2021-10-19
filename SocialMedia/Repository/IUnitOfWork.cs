using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ISocialMediaRepository SocialMediaInfo { get; }
        int Complete();
    }
}
