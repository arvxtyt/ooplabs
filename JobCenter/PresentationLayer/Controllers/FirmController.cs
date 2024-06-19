using BusinessLogicLayer;
using BusinessLogicLayer.Entities;  
using BusinessLogicLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class FirmController
    {
        private FirmService firmService;

        public FirmController(DbContext context, Mapper mapper)
        {
            firmService = new FirmService(context, mapper);
        }

        public async Task ShowFirm(long id)
        {
            Console.WriteLine("ID  |Name                          |Phone       |Email               |Site                          |Rating");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            var res = await firmService.GetFirm(id);

            Console.WriteLine(res.ToString());
        }

        public async Task ShowAllFirms()
        {
            Console.WriteLine("ID  |Name                          |Phone       |Email               |Site                          |Rating");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            var firms = await firmService.GetAllFirms();

            foreach (var firm in firms)
            {
                Console.WriteLine(firm.ToString());
            }
        }

        public async Task AddFirm()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Phone: ");
            var phone = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Site: ");
            var site = Console.ReadLine();
            Console.Write("Rating: ");
            var rating = int.Parse(Console.ReadLine());

            var firm = new Firm
            {
                Name = name,
                Email = email,
                Phone = phone,
                Rating = rating,
                Site = site,
            };

            await firmService.CreateFirm(firm);

            Console.WriteLine("ID  |Name                          |Phone       |Email               |Site                          |Rating");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine(firm.ToString());
        }

        public async Task deleteFirm(long id)
        {
            await firmService.DeleteFirm(id);
        }

        internal async Task EditFirm(long id)
        {
            var firm = await firmService.GetFirm(id);

            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Phone: ");
            var phone = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Site: ");
            var site = Console.ReadLine();
            Console.Write("Rating: ");
            var rating = Console.ReadLine();

            if (name != "")
            {
                firm.Name = name;
            }

            if (phone != "")
            {
                firm.Phone = phone;
            }

            if (email != "")
            {
                firm.Email = email;
            }

            if (site != "" ){
                firm.Site = site;
            }

            if (rating != "")
            {
                firm.Rating = int.Parse(rating);
            }

            await firmService.UpdateFirm(firm);

            Console.WriteLine("ID  |Name                          |Phone       |Email               |Site                          |Rating");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine(firm.ToString());
        }

        public async Task SortFirms()
        {
            Console.WriteLine("Ascending(y): ");
            bool ascending = Console.ReadLine() != "n";
            var firms = await firmService.SortFirms(ascending);

            Console.WriteLine("ID  |Name                          |Phone       |Email               |Site                          |Rating");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            foreach (var firm in firms)
            {
                Console.WriteLine(firm.ToString());
            }

        }

        public async Task GetVacancies(int v)
        {
            var firm = await firmService.GetFirm(v);
            var vacs = await firmService.GetVacanciesOfFirm(v);

            Console.WriteLine("ID  |Name                          |Phone       |Email               |Site                          |Rating");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine(firm.ToString());

            Console.WriteLine("ID  |Firm id|Firm name                       |Field id|Field name|Title                         |Description                   |Created At|Updated At");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var vacancy in vacs)
            {
                Console.WriteLine(vacancy.ToString());
            }
        }

        internal async Task Search(string input)
        {
            var firms = await firmService.SearchFirm(input);

            Console.WriteLine("ID  |Name                          |Phone       |Email               |Site                          |Rating");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            foreach (var item in firms)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
