using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Service
{
    public interface IService
    {
        IEnumerable<SocialMedia.Model.SocialMedia> Get();
        SocialMedia.Model.SocialMedia GetByID(int id);
        void Add(SocialMedia.Model.SocialMedia model);
        void Delete(int id);
    }
}
