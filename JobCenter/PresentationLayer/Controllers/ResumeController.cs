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
    internal class ResumeController
    {
        private ResumeService resumeService;

        public ResumeController(DbContext context, Mapper mapper)
        {
            resumeService = new ResumeService(context, mapper);            
        }

        internal async Task AddResume()
        {
            Console.Write("Unemployed id: ");
            var uneId = int.Parse(Console.ReadLine());
            Console.Write("Field id: ");
            var fieId = int.Parse(Console.ReadLine());
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Description: ");
            var desc = Console.ReadLine();

            var resume = new Resume
            {
                FieldId = fieId,
                Description = desc,
                Title = title,
                UnemployedId = uneId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await resumeService.CreateResume(resume);

            Console.WriteLine("ID  |Title               |Description                    |Field id|Field name          |UnId|Unemployed name     |Created at|Updated at");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(resume.ToString());
        }

        internal async Task DeleteResume(int v)
        {
            await resumeService.DeleteResume(v);
        }

        internal async Task EditResume(int v)
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Description: ");
            var desc = Console.ReadLine();

            var resume = await resumeService.GetResume(v);

            if (title != "")
            {
                resume.Title = title;
            }

            if (desc != "")
            {
                resume.Description = desc;
            }

            await resumeService.UpdateResume(resume);

            Console.WriteLine("ID  |Title               |Description                    |Field id|Field name          |UnId|Unemployed name     |Created at|Updated at");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(resume);
        }

        internal async Task ShowAllResumes()
        {
            var resumes = await resumeService.GetAllResumes();

            Console.WriteLine("ID  |Title               |Description                    |Field id|Field name          |UnId|Unemployed name     |Created at|Updated at");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var item in resumes)
            {
                Console.WriteLine(item.ToString());
            }
        }

        internal async Task ShowResume(int v)
        {
            var resume = await resumeService.GetResume(v);
            Console.WriteLine("ID  |Title               |Description                    |Field id|Field name          |UnId|Unemployed name     |Created at|Updated at");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(resume.ToString());
        }
    }
}
