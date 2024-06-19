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
    public class UnemployedService
    {
        private UnemployedRepository repository;
        private ApplicationRepository applicationRepository;
        private ResumeRepository resumeRepository;
        private Mapper mapper;

        public UnemployedService(DbContext context, Mapper mapper)
        {
            repository = new UnemployedRepository(context);
            applicationRepository = new ApplicationRepository(context);
            resumeRepository = new ResumeRepository(context);
            this.mapper = mapper;
        }

        public async Task CreateUnemployed(Unemployed entity)
        {
            await repository.Create(mapper.Map(entity));
        }

        public async Task DeleteUnemployed(long id)
        {
            var unemployed = await repository.ReadById(id);
            await repository.Delete(unemployed);
        }

        public async Task<Unemployed> GetUnemployed(int id)
        {
            return mapper.Map(await repository.ReadById(id));
        }

        public async Task<ICollection<Application>> GetApplicationsOfUnemployed(long id)
        {
            return (await applicationRepository.ReadAll())
                .Where(x => x.UnemployedId == id)
                .Select(x => mapper.Map(x))
                .ToList();
        }

        public async Task<ICollection<Resume>> GetResumesOfUnemployed(long id)
        {
            return (await resumeRepository.ReadAll())
                .Where(x => x.UnemployedId == id)
                .Select(x => mapper.Map(x))
                .ToList();
        }

        public async Task<ICollection<Unemployed>> GetAllUnemployeds()
        {
            return (await repository.ReadAll()).Select(x => mapper.Map(x)).ToList();
        }

        public async Task UpdateUnemployed(Unemployed entity)
        {
            await repository.Update(mapper.Map(entity));
        }

        public async Task<ICollection<Unemployed>> SearchUnemployed(string name)
        {
            return (await GetAllUnemployeds())
                .Where(u => (u.Name + u.Surname).Contains(name) || u.Phone.Contains(name))
                .ToList();       
        }

        public async Task<ICollection<Unemployed>> SortUnemployedByName(bool descending = false)
        {
            if (descending)
            {
                return (await GetAllUnemployeds()).OrderByDescending(x => x.Name).ToList();
            }

            return (await GetAllUnemployeds()).OrderBy(x => x.Name).ToList();
        }

        public async Task<ICollection<Unemployed>> SortUnemployedBySurname(bool descending = false)
        {
            if (descending)
            {
                return (await GetAllUnemployeds()).OrderByDescending(x => x.Surname).ToList();
            }

            return (await GetAllUnemployeds()).OrderBy(x => x.Surname).ToList();
        }
    }
}
