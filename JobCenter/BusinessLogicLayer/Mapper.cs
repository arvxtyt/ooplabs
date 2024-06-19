using AutoMapper;
using BusinessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Mapper
    {
        public DataAccessLayer.Models.Application Map(Application entity)
        {
            var model = new DataAccessLayer.Models.Application
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                CreatedAt = entity.CreatedAt,
                UnemployedId = entity.UnemployedId,
                VacancyId = entity.VacancyId,
                UpdatedAt = DateTime.Now
            };

            return model;
        }

        public Application Map(DataAccessLayer.Models.Application model)
        {
            var entity = new Application
            {
                Id = model.Id,
                CategoryId = model.CategoryId,
                CategoryName = model.Category.Name,
                UnemployedName = model.Unemployed.Name,
                VacancyName = model.Vacancy.Title,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                UnemployedId = model.UnemployedId,
                VacancyId = model.VacancyId
            };

            return entity;
        }

        public Category Map(DataAccessLayer.Models.Category model)
        {
            var entity = new Category
            {
                Id = model.Id,
                Name = model.Name,
                Applications = (model.Applications != null) ? model.Applications.Select(x => Map(x)).ToList() : new List<Application>(),
            };

            return entity;
        }

        public DataAccessLayer.Models.Category Map(Category entity)
        {
            var model = new DataAccessLayer.Models.Category
            {
                Id = entity.Id,
                Name = entity.Name,
                Applications = entity.Applications.Select(x => Map(x)).ToList(),
            };

            return model;
        }

        public DataAccessLayer.Models.Field Map(Field entity)
        {
            var model = new DataAccessLayer.Models.Field
            {
                Id = entity.Id,
                Name = entity.Name,
                Resumes = entity.Resumes.Select(x => Map(x)).ToList(),
                Vacancies = entity.Vacancies.Select(x => Map(x)).ToList()
            };

            return model;
        }

        public Field Map(DataAccessLayer.Models.Field model)
        {
            var entity = new Field
            {
                Id = model.Id,
                Name = model.Name,
                Resumes = (model.Resumes != null) ? model.Resumes.Select(x => Map(x)).ToList() : new List<Resume>(),
                Vacancies = (model.Resumes != null) ? model.Vacancies.Select(x => Map(x)).ToList() : new List<Vacancy>(),
            };

            return entity;
        }

        public DataAccessLayer.Models.Firm Map(Firm entity)
        {
            var model = new DataAccessLayer.Models.Firm
            {
                Id = entity.Id,
                Email = entity.Email,
                Name = entity.Name,
                Phone = entity.Phone,
                Rating = entity.Rating,
                Site = entity.Site,
                Vacancies = entity.Vacancies.Select(x => Map(x)).ToList()
            };

            return model;
        }

        public Firm Map(DataAccessLayer.Models.Firm model)
        {
            var entity = new Firm
            {
                Id = model.Id,
                Email = model.Email,
                Name = model.Name,
                Phone = model.Phone,
                Rating = model.Rating,
                Site = model.Site,
                Vacancies = (model.Vacancies != null) ? model.Vacancies.Select(x => Map(x)).ToList() : new List<Vacancy>()
            };

            return entity;
        }

        public DataAccessLayer.Models.Resume Map(Resume entity)
        {
            var model = new DataAccessLayer.Models.Resume
            {
                Id = entity.Id,
                FieldId = entity.FieldId,
                CreatedAt = entity.CreatedAt,
                Description = entity.Description,
                Title = entity.Title,
                UnemployedId = entity.UnemployedId,
                UpdatedAt = DateTime.Now,
            };

            return model;
        }

        public Resume Map(DataAccessLayer.Models.Resume model)
        {
            var entity = new Resume
            {
                Id = model.Id,
                FieldName = model.Field.Name,
                UnemployedName = $"{model.Unemployed.Name} {model.Unemployed.Surname}",
                CreatedAt = model.CreatedAt,
                Description = model.Description,
                FieldId = model.FieldId,
                Title = model.Title,
                UnemployedId = model.UnemployedId,
                UpdatedAt = model.UpdatedAt,
            };

            return entity;
        }

        public DataAccessLayer.Models.Unemployed Map(Unemployed entity)
        {
            var model = new DataAccessLayer.Models.Unemployed
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                DateOfBirth = entity.DateOfBirth,
                Description = entity.Description,
                Email = entity.Email,
                Name = entity.Name,
                Surname = entity.Surname,
                UpdatedAt = DateTime.Now,
                Phone = entity.Phone,
                Resumes = entity.Resumes.Select(x => Map(x)).ToList(),
                Applications = entity.Applications.Select(x => Map(x)).ToList(),
            };

            return model;
        }

        public Unemployed Map(DataAccessLayer.Models.Unemployed model)
        {
            var entity = new Unemployed
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                DateOfBirth = model.DateOfBirth,
                Description = model.Description,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Phone = model.Phone,
                UpdatedAt = model.UpdatedAt,
                Resumes = (model.Resumes != null) ? model.Resumes.Select(x => Map(x)).ToList() : new List<Resume>(),
                Applications = (model.Applications != null) ? model.Applications.Select(x => Map(x)).ToList() : new List<Application>(),
            };

            return entity;
        }

        public DataAccessLayer.Models.Vacancy Map(Vacancy entity)
        {
            var model = new DataAccessLayer.Models.Vacancy
            {
                Id = entity.Id,
                Applictions = entity.Applications.Select(x => Map(x)).ToList(),
                CreatedAt = entity.CreatedAt,
                Description = entity.Description,
                FieldId = entity.FieldId,
                FirmId = entity.FirmId,
                Title = entity.Title,
                UpdatedAt = DateTime.Now,
            };

            return model;
        }

        public Vacancy Map(DataAccessLayer.Models.Vacancy model)
        {
            var entity = new Vacancy
            {
                Id = model.Id,
                FieldId = model.FieldId,
                Applications = (model.Applictions != null) ? model.Applictions.Select(x => Map(x)).ToList() : new List<Application>(),
                CreatedAt = model.CreatedAt, 
                Description = model.Description,
                FirmId = model.FirmId,
                Title = model.Title,
                UpdatedAt = model.UpdatedAt,
                FieldName = model.Field.Name,
                FirmName = model.Firm.Name,
            };

            return entity;
        }
    }
}
