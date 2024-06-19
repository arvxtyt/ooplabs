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
    public class ResumeRepository : IRepository<Resume>
    {
        private JobCentreContext context;

        public ResumeRepository(DbContext context)
        {
            this.context = context as JobCentreContext;
        }
        public async Task Create(Resume model)
        {
            await context.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Resume model)
        {
            context.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Resume>> ReadAll()
        {
            return await context.Resumes
                .Include(x => x.Unemployed)
                .Include(x => x.Field)
                .ToListAsync();
        }

        public async Task<Resume?> ReadById(long id)
        {
            return await context.Resumes
                .Include(x => x.Field)
                .Include(x => x.Unemployed)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Resume model)
        {
            context.ChangeTracker.Clear();
            context.Resumes.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
