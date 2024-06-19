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
    public class UnemployedRepository : IRepository<Unemployed>
    {
        private JobCentreContext context;

        public UnemployedRepository(DbContext context)
        {
            this.context = context as JobCentreContext;
        }
        public async Task Create(Unemployed model)
        {
            await context.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Unemployed model)
        {
            context.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Unemployed>> ReadAll()
        {
            return await context.Unemployeds.ToListAsync();
        }

        public async Task<Unemployed?> ReadById(long id)
        {
            return await context.Unemployeds.FindAsync(id);
        }

        public async Task Update(Unemployed model)
        {
            context.ChangeTracker.Clear();
            context.Unemployeds.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
