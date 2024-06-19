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
    public class CategoryService
    {
        private CategoryRepository repository;
        private ApplicationRepository applicationRepository;
        private Mapper mapper;

        public CategoryService(DbContext context, Mapper mapper)
        {
            repository = new CategoryRepository(context);
            applicationRepository = new ApplicationRepository(context);
            this.mapper = mapper;
        }

        public async Task<ICollection<Application>> GetApplicationsOfCategory(long id)
        {
            return (await applicationRepository.ReadAll())
                .Where(x => x.CategoryId == id)
                .Select(x => mapper.Map(x))
                .ToList();
        }

        public async Task<Category> GetCategory(int id)
        {
            return mapper.Map(await repository.ReadById(id));
        }

        public async Task<ICollection<Category>> GetAllCategories()
        {
            return (await repository.ReadAll()).Select(x => mapper.Map(x)).ToList();
        }

        //public async Task<ICollection<Application>> GetApplicationsForCategory(long id)
        //{
        //    var k = await repository.ReadById(id);
        //    return (k.Applications) != null k.Applications.Select(x => mapper.Map(x)).ToList();
        //}
    }
}
