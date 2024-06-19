using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ApplicationRepository : IRepository<Application>
    {
        private JobCentreContext context;

        public ApplicationRepository(DbContext context)
        {
            this.context = context as JobCentreContext;
        }
        public async Task Create(Application model)
        {
            await context.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Application model)
        {
            context.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Application>> ReadAll()
        {
            return await context.Applications
                .Include(x => x.Category)
                .Include(x => x.Unemployed)
                .Include(x => x.Vacancy)
                .ToListAsync();
        }

        public async Task<Application?> ReadById(long id)
        {
            return await context.Applications
                .Include(x => x.Category)
                .Include(x => x.Unemployed)
                .Include(x => x.Vacancy)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Application model)
        {
            context.ChangeTracker.Clear();
            context.Applications.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
