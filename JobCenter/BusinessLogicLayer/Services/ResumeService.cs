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
    public class ResumeService
    {
        private ResumeRepository repository;
        private Mapper mapper;

        public ResumeService(DbContext context, Mapper mapper)
        {
            repository = new ResumeRepository(context);
            this.mapper = mapper;
        }

        public async Task CreateResume(Resume entity)
        {
            await repository.Create(mapper.Map(entity));
        }

        public async Task DeleteResume(long id)
        {
            var model = await repository.ReadById(id);
            await repository.Delete(model);
        }

        public async Task<Resume> GetResume(int id)
        {
            return mapper.Map(await repository.ReadById(id));
        }

        public async Task<ICollection<Resume>> GetAllResumes()
        {
            return (await repository.ReadAll()).Select(x => mapper.Map(x)).ToList();
        }

        public async Task UpdateResume(Resume entity)
        {
            await repository.Update(mapper.Map(entity));
        }

        public async Task<ICollection<Resume>> SortResumes(bool descending = false)
        {
            if (descending)
            {
                return (await GetAllResumes()).OrderByDescending(x => x.CreatedAt).ToList();
            }

            return (await GetAllResumes()).OrderBy(x => x.CreatedAt).ToList();
        }
    }
}
