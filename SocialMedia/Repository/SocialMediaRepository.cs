using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Repository
{
    public class SocialMediaRepository : GenericRepository<SocialMedia.Model.SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(ApplicationDBContext db) : base(db)
        {
        }

        public IEnumerable<Model.SocialMedia> GetSocialInfoByName(string Name)
        {
            return _db.SocialMedia.Where(s => s.Name.Contains(Name)).ToList();
        }
    }
}
