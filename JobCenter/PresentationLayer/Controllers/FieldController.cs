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
    internal class FieldController
    {
        private FieldService fieldService;

        public FieldController(DbContext context, Mapper mapper)
        {
            fieldService = new FieldService(context, mapper);
        }
        public async Task AddField()
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            var field = new Field
            {
                Name = name,
            };

            await fieldService.CreateField(field);
        }

        public async Task EditField(int v)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            var field = await fieldService.GetField(v);

            field.Name = name;

            await fieldService.UpdateField(field);

            Console.WriteLine("ID  |Name                ");
            Console.WriteLine("-------------------------");
            Console.WriteLine(field.ToString());
        }

        public async Task ShowAllFields()
        {
            var fields = await fieldService.GetAllFields();

            Console.WriteLine("ID  |Name                ");
            Console.WriteLine("-------------------------");
            foreach (var field in fields)
            {
                Console.WriteLine(field.ToString());
            }
        }

        public async Task ShowField(int v)
        {
            var field = await fieldService.GetField(v);

            Console.WriteLine("ID  |Name                ");
            Console.WriteLine("-------------------------");
            Console.WriteLine(field.ToString());
        }

    }
}
