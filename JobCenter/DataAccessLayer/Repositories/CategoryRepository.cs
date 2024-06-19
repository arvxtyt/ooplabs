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
    public class CategoryRepository : IRepository<Category>
    {
        private JobCentreContext context;

        public CategoryRepository(DbContext context)
        {
            this.context = context as JobCentreContext;
        }
        public async Task Create(Category model)
        {
            await context.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Category model)
        {
            context.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> ReadAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category?> ReadById(long id)
        {
            return await context.Categories.Include(x => x.Applications).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Category model)
        {
            context.ChangeTracker.Clear();
            context.Categories.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
