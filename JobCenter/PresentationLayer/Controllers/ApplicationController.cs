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
    public class ApplicationController
    {
        private ApplicationService applicationService;
        private CategoryService categoryService;

        public ApplicationController(DbContext context, Mapper mapper)
        {
            applicationService = new ApplicationService(context, mapper);
            categoryService = new CategoryService(context, mapper);
        }

        public async Task AddApplication()
        {
            Console.Write("Vacancy id: ");
            var vacId = int.Parse(Console.ReadLine());
            Console.Write("Unemployed id: ");
            var uneId = int.Parse(Console.ReadLine());

            var application = new Application
            {
                CategoryId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                VacancyId = vacId,
                UnemployedId = uneId,
            };

            await applicationService.CreateApplication(application);

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(application.ToString());
        }

        public async Task ChangeCategory(int v)
        {
            Console.WriteLine("Categories:");
            Console.WriteLine("ID  |Name      ");
            Console.WriteLine("---------------");
            foreach (var item in await categoryService.GetAllCategories())
            {
                Console.WriteLine(item.ToString());
            }

            Console.Write("Category id: ");
            var cat = Console.ReadLine();
            var app = await applicationService.GetApplication(v);

            app.CategoryId = int.Parse(cat);

            await applicationService.UpdateApplication(app);

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(app.ToString());
        }

        public async Task DeleteApplication(int v)
        {
            await applicationService.DeleteApplication(v);
        }
    }
}
