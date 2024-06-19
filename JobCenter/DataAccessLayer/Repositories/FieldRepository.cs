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
    public class FieldRepository : IRepository<Field>
    {
        private JobCentreContext context;

        public FieldRepository(DbContext context)
        {
            this.context = context as JobCentreContext;
        }
        public async Task Create(Field model)
        {
            await context.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Field model)
        {
            context.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Field>> ReadAll()
        {
            return await context.Fields.ToListAsync();
        }

        public async Task<Field?> ReadById(long id)
        {
            return await context.Fields.FindAsync(id);
        }

        public async Task Update(Field model)
        {
            context.ChangeTracker.Clear();
            context.Fields.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
