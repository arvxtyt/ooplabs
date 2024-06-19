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
    public class FieldService
    {
        private FieldRepository repository;
        private Mapper mapper;

        public FieldService(DbContext context, Mapper mapper)
        {
            repository = new FieldRepository(context);
            this.mapper = mapper;
        }

        public async Task CreateField(Field entity)
        {
            await repository.Create(mapper.Map(entity));
        }

        public async Task DeleteField(Field entity)
        {
            await repository.Delete(mapper.Map(entity));
        }

        public async Task<Field> GetField(int id)
        {
            return mapper.Map(await repository.ReadById(id));
        }

        public async Task<ICollection<Field>> GetAllFields()
        {
            return (await repository.ReadAll()).Select(x => mapper.Map(x)).ToList();
        }

        public async Task UpdateField(Field entity)
        {
            await repository.Update(mapper.Map(entity));
        }
    }
}
