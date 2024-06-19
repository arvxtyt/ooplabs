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
    internal class CategoryController
    {
        private CategoryService categoryService;

        public CategoryController(DbContext context, Mapper mapper)
        {
            categoryService = new CategoryService(context, mapper);
        }

        internal async Task ShowApproved()
        {
            var applications = await categoryService.GetApplicationsOfCategory(2);

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var item in applications)
            {
                Console.WriteLine(item.ToString());
            }
        }

        internal async Task ShowDeclined()
        {
            var applications = await categoryService.GetApplicationsOfCategory(3);

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var item in applications)
            {
                Console.WriteLine(item.ToString());
            }
        }

        internal async Task ShowPending()
        {
            var applications = await categoryService.GetApplicationsOfCategory(1);

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var item in applications)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
