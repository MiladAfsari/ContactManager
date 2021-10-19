using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<SocialMedia.Model.SocialMedia> SocialMedia { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        internal Task<object> FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
