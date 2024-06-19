using BusinessLogicLayer;
using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    internal class VacancyController
    {
        private VacancyService vacancyService;

        public VacancyController(DbContext context, Mapper mapper)
        {
            vacancyService = new VacancyService(context, mapper);
        }

        public async Task AddVacancy()
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Description: ");
            var description = Console.ReadLine();
            Console.Write("Firm id: ");
            var firmId = int.Parse(Console.ReadLine());
            Console.Write("Field id: ");
            var fieldId = int.Parse(Console.ReadLine());

            var vacancy = new Vacancy
            {
                Title = title,
                Description = description,
                FieldId = fieldId,
                FirmId = firmId,
                CreatedAt = DateTime.Now
            };

            await vacancyService.CreateVacancy(vacancy);
        }

        public async Task DeleteVacancy(int v)
        {
            await vacancyService.DeleteVacany(v);
        }

        public async Task EditVacancy(int v)
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Description: ");
            var description = Console.ReadLine();
            Console.Write("Firm id: ");
            var firmId = Console.ReadLine();
            Console.Write("Field id: ");
            var fieldId = Console.ReadLine();

            var vacancy = await vacancyService.GetVacancy(v);

            if (title != "")
            {
                vacancy.Title = title;
            }

            if (description != "")
            {
                vacancy.Description = description;
            }

            if (firmId != "")
            {
                vacancy.FirmId = int.Parse(firmId);
            }

            if (fieldId != "")
            {
                vacancy.FieldId = int.Parse(fieldId);
            }

            await vacancyService.UpdateVacancy(vacancy);

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(vacancy.ToString());
        }

        public async Task GetApplicationsForVacancy(int v)
        {
            var applications = await vacancyService.GetApplicationsForVacancy(v);
            var vacancy = await vacancyService.GetVacancy(v);

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(vacancy.ToString());
            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var app in applications)
            {
                Console.WriteLine(app.ToString());
            }
        }

        public async Task ShowAllVacancies()
        {
            var vacs = await vacancyService.GetAllVacancies();

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var vacancy in vacs)
            {
                Console.WriteLine(vacancy.ToString());
            }
        }

        public async Task ShowVacancy(int v)
        {
            var vacancy = await vacancyService.GetVacancy(v);

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(vacancy.ToString());
        }

        public async Task SortVacancies()
        {
            Console.WriteLine("Descending(n): ");
            var descending = Console.ReadLine() == "y";

            var vacs = await vacancyService.SortVacancies(descending);

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var vacancy in vacs)
            {
                Console.WriteLine(vacancy.ToString());
            }
        }
    }
}
