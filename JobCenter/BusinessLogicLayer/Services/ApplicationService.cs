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
    public class ApplicationService
    {
        private ApplicationRepository repository;
        private Mapper mapper;

        public ApplicationService(DbContext context, Mapper mapper)
        {
            repository = new ApplicationRepository(context);
            this.mapper = mapper;
        }

        public async Task CreateApplication(Application entity)
        {
            await repository.Create(mapper.Map(entity));
        }

        public async Task DeleteApplication(long id)
        {
            var model = await repository.ReadById(id);

            await repository.Delete(model);
        }

        public async Task<Application> GetApplication(int id)
        {
            return mapper.Map(await repository.ReadById(id));
        }

        public async Task<ICollection<Application>> GetAllApplications()
        {
            return (await repository.ReadAll()).Select(a => mapper.Map(a)).ToList();
        }

        public async Task UpdateApplication(Application entity)
        {
            await repository.Update(mapper.Map(entity));
        }
    }
}
