using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FirmRepository : IRepository<Firm>
    {
        private JobCentreContext context;

        public FirmRepository(DbContext context)
        {
            this.context = context as JobCentreContext;
        }
        public async Task Create(Firm model)
        {
            await context.Firms.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Firm model)
        {
            context.Firms.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Firm>> ReadAll()
        {
            return await context.Firms.ToListAsync();
        }

        public async Task<Firm?> ReadById(long id)
        {
            return await context.Firms.FindAsync(id);
        }

        public async Task Update(Firm model)
        {
            context.ChangeTracker.Clear();
            context.Firms.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
