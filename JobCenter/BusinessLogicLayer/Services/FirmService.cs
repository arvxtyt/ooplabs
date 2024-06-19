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
    public class FirmService
    {
        private FirmRepository repository;
        private VacancyRepository vacancyRepository;
        private Mapper mapper;

        public FirmService(DbContext context, Mapper mapper)
        {
            repository = new FirmRepository(context);
            vacancyRepository = new VacancyRepository(context);
            this.mapper = mapper;
        }

        public async Task CreateFirm(Firm entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "can't be null");
            }

            await repository.Create(mapper.Map(entity));
        }

        public async Task DeleteFirm(long id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (await repository.ReadById(id) == null)
            {
                throw new RecordNotExists(id);
            }

            var firm = await repository.ReadById(id);


            await repository.Delete(firm);
        }

        public async Task<Firm> GetFirm(long id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var entity = await repository.ReadById(id);
            
            if (entity == null)
            {
                throw new RecordNotExists(id);
            }

            return mapper.Map(entity);
        }

        public async Task<ICollection<Vacancy>> GetVacanciesOfFirm(long id)
        {
            return (await vacancyRepository.ReadAll())
                .Where(x => x.FirmId == id)
                .Select(x => mapper.Map(x))
                .ToList();
        }

        public async Task<ICollection<Firm>> GetAllFirms()
        {
            return (await repository.ReadAll()).Select(x => mapper.Map(x)).ToList();
        }

        public async Task UpdateFirm(Firm entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "can't be null");
            }

            await repository.Update(mapper.Map(entity));
        }

        public async Task<ICollection<Firm>> SearchFirm(string name)
        {
            return (await GetAllFirms())
                .Where(f => f.Name.Contains(name) 
                    || f.Phone.Contains(name)
                    || f.Site.Contains(name))
                .ToList();
        }

        public async Task<ICollection<Firm>> SortFirms(bool ascending)
        {
            if (ascending)
            {
                return (await GetAllFirms()).OrderBy(x => x.Name).ToList();
            }

            return (await GetAllFirms()).OrderByDescending(x => x.Name).ToList();
        }
    }
}
