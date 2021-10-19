using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public ISocialMediaRepository SocialMediaInfo { get; }


        public UnitOfWork(ApplicationDBContext db, ISocialMediaRepository socialMediaRepository)
        {
            _db = db;
            SocialMediaInfo = socialMediaRepository;
        }


        public int Complete()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}
