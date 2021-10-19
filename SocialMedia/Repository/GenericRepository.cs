using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDBContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDBContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public  async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
