using BusinessLogicLayer;
using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    internal class UnemployedController
    {
        private UnemployedService unemployedService;

        public UnemployedController(DbContext context, Mapper mapper)
        {
            unemployedService = new UnemployedService(context, mapper);
        }
        public async Task AddUnemployed()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Surname: ");
            var surname = Console.ReadLine();
            Console.Write("Phone: ");
            var phone = Console.ReadLine();
            Console.Write("Date of birth: ");
            var date = DateTime.Parse(Console.ReadLine());
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Description: ");
            var description = Console.ReadLine();

            var unemployed = new Unemployed
            {
                Name = name,
                Surname = surname,
                DateOfBirth = date,
                Description = description,
                Email = email,
                Phone = phone,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await unemployedService.CreateUnemployed(unemployed);

            Console.WriteLine("ID  |Name          |Surname        |Phone       |Email               |Description         |Created at          |Updated at          ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(unemployed.ToString());
        }

        internal async Task DeleteUnemployed(int v)
        {
            await unemployedService.DeleteUnemployed(v);
        }

        internal async Task EditUnemployed(int v)
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Surname: ");
            var surname = Console.ReadLine();
            Console.Write("Phone: ");
            var phone = Console.ReadLine();
            Console.Write("Date of birth: ");
            var date = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Description: ");
            var description = Console.ReadLine();

            var unemployed = await unemployedService.GetUnemployed(v);
            if (name != "")
            {
                unemployed.Name = name;
            }

            if (surname != "")
            {
                unemployed.Surname = surname;
            }

            if (email != "")
            {
                unemployed.Email = email;
            }

            if (phone != "")
            {
                unemployed.Phone = phone;
            }

            if (description != "")
            {
                unemployed.Description = description;
            }

            if (date != "")
            {
                unemployed.DateOfBirth = DateTime.Parse(date);
            }

            unemployed.UpdatedAt = DateTime.Now;

            await unemployedService.UpdateUnemployed(unemployed);

            Console.WriteLine("ID  |Name          |Surname        |Phone       |Email               |Description         |Created at          |Updated at          ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(unemployed.ToString());
        }

        internal async Task GetApplicationsOfUnemployed(int v)
        {
            var unemployed = await unemployedService.GetUnemployed(v);
            var applications = await unemployedService.GetApplicationsOfUnemployed(v);

            Console.WriteLine("ID  |Name          |Surname        |Phone       |Email               |Description         |Created at          |Updated at          ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(unemployed.ToString());

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var item in applications)
            {
                Console.WriteLine(item.ToString());
            }
        }

        internal async Task GetResumesOfUnemployed(int v)
        {
            var unemployed = await unemployedService.GetUnemployed(v);
            Console.WriteLine("ID  |Name          |Surname        |Phone       |Email               |Description         |Created at          |Updated at          ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(unemployed.ToString());

            var resumes = await unemployedService.GetResumesOfUnemployed(v);

            Console.WriteLine("ID  |Title               |Description                    |Field id|Field name          |UnId|Unemployed name     |Created at|Updated at");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var item in resumes)
            {
                Console.WriteLine(item.ToString());
            }
        }

        internal async Task Search(string input)
        {
            var unemployeds = await unemployedService.SearchUnemployed(input);

            Console.WriteLine("ID  |Name          |Surname        |Phone       |Email               |Description         |Created at          |Updated at          ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var item in unemployeds)
            {
                Console.WriteLine(item.ToString());
            }
        }

        internal async Task ShowAllUnemployeds()
        {
            var unemployeds = await unemployedService.GetAllUnemployeds();

            Console.WriteLine("ID  |Name          |Surname        |Phone       |Email               |Description         |Created at          |Updated at          ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");

            foreach (var item in unemployeds)
            {
                Console.WriteLine(item.ToString());
            }
        }

        internal async Task ShowUnemployed(int v)
        {
            var unemployed = await unemployedService.GetUnemployed(v);

            Console.WriteLine("ID  |Name          |Surname        |Phone       |Email               |Description         |Created at          |Updated at          ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(unemployed.ToString());
        }
    }
}
