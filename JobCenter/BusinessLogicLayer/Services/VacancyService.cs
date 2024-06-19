using BusinessLogicLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class VacancyService
    {
        private VacancyRepository repository;
        private ApplicationRepository applicationRepository;
        private Mapper mapper;

        public VacancyService(DbContext context, Mapper mapper)
        {
            repository = new VacancyRepository(context);
            applicationRepository = new ApplicationRepository(context);
            this.mapper = mapper;
        }

        public async Task CreateVacancy(Vacancy entity)
        {
            await repository.Create(mapper.Map(entity));
        }

        public async Task DeleteVacany(long id)
        {
            var vacancy = await repository.ReadById(id);

            await repository.Delete(vacancy);
        }

        public async Task<Vacancy> GetVacancy(long id)
        {
            return mapper.Map(await repository.ReadById(id));
        }

        public async Task<ICollection<Application>> GetApplicationsForVacancy(long id)
        {
            return (await applicationRepository.ReadAll())
                .Where(x => x.VacancyId == id)
                .Select(x => mapper.Map(x))
                .ToList();
        }

        public async Task<ICollection<Vacancy>> GetAllVacancies()
        {
            return (await repository.ReadAll()).Select(x => mapper.Map(x)).ToList();
        }

        public async Task UpdateVacancy(Vacancy entity)
        {
            await repository.Update(mapper.Map(entity));
        }

        public async Task<ICollection<Vacancy>> SortVacancies(bool descending = false)
        {
            if (descending)
            {
                return (await GetAllVacancies()).OrderByDescending(x => x.CreatedAt).ToList();
            }
            
            return (await GetAllVacancies()).OrderBy(x => x.CreatedAt).ToList();
        }
    }
}
