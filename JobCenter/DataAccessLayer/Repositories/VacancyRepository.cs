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
    public class VacancyRepository : IRepository<Vacancy>
    {
        private JobCentreContext context;

        public VacancyRepository(DbContext context)
        {
            this.context = context as JobCentreContext;
        }
        public async Task Create(Vacancy model)
        {
            await context.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Vacancy model)
        {
            context.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vacancy>> ReadAll()
        {
            return await context.Vacancies
                .Include(x => x.Field)
                .Include(x => x.Firm)
                .ToListAsync();
        }
        
        public async Task<Vacancy?> ReadById(long id)
        {
            return await context.Vacancies
                .Include(x => x.Firm)
                .Include(x => x.Field)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Vacancy model)
        {
            context.ChangeTracker.Clear();
            context.Vacancies.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
