using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Repository
{
    public interface ISocialMediaRepository : IGenericRepository<SocialMedia.Model.SocialMedia>
    {
        IEnumerable<SocialMedia.Model.SocialMedia> GetSocialInfoByName(string Name);
    }
}
