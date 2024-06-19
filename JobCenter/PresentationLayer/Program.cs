using BusinessLogicLayer;
using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using PresentationLayer.Controllers;

namespace PresentationLayer.Program
{
    public static class Program
    {
        public static async Task Main()
        {
            string input = "";
            var context = new JobCentreContext();
            var mapper = new Mapper();
            var firmController = new FirmController(context, mapper);
            var vacancyController = new VacancyController(context, mapper);
            var fieldController = new FieldController(context, mapper);
            var applicationController = new ApplicationController(context, mapper);
            var unemployedController = new UnemployedController(context, mapper);
            var resumeController = new ResumeController(context, mapper);
            var categoryController = new CategoryController(context, mapper);

            do
            {
                Console.WriteLine("1) Firms\n2) Vacancies\n3) Fields\n4) Applications\n5) Unemployeds\n6) Resumes\n7) Categories\n8) Exit");
                input = Console.ReadLine()!;
                switch (input)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("1) Get firm by id\n2) Get all firms\n3) Add firm\n4) Delete firm\n5) Edit firm\n6) Sort firm\n7) Get vacancies for firm\ne) Exit");
                            input = Console.ReadLine()!;
                            switch (input)
                            {
                                case "1":
                                    input = Console.ReadLine()!;
                                    await firmController.ShowFirm(int.Parse(input));
                                    break;
                                case "2":
                                    await firmController.ShowAllFirms();
                                    break;
                                case "3":
                                    await firmController.AddFirm();
                                    break;
                                case "4":
                                    input = Console.ReadLine()!;
                                    await firmController.deleteFirm(int.Parse(input));
                                    break;
                                case "5":
                                    input = Console.ReadLine()!;
                                    await firmController.EditFirm(int.Parse(input));
                                    break;
                                case "6":
                                    await firmController.SortFirms();
                                    break;
                                case "7":
                                    input = Console.ReadLine()!;
                                    await firmController.GetVacancies(int.Parse(input));
                                    break;
                                case "8":
                                    input = Console.ReadLine()!;
                                    await firmController.Search(input);
                                    break;
                            }
                        } while (input != "e");
                        break;
                    case "2":
                        do
                        {
                            Console.WriteLine("1) Get vacancy by id\n2) Get all vacancies\n3) Add vacancy\n4) Delete vacancy\n5) Edit vacancy\n6) Sort vacancies\n7) Get applications for vacancy\ne) Exit");
                            input = Console.ReadLine()!;
                            switch (input)
                            {
                                case "1":
                                    input = Console.ReadLine()!;
                                    await vacancyController.ShowVacancy(int.Parse(input));
                                    break;
                                case "2":
                                    await vacancyController.ShowAllVacancies();
                                    break;
                                case "3":
                                    await vacancyController.AddVacancy();
                                    break;
                                case "4":
                                    input = Console.ReadLine()!;
                                    await vacancyController.DeleteVacancy(int.Parse(input));
                                    break;
                                case "5":
                                    input = Console.ReadLine()!;
                                    await vacancyController.EditVacancy(int.Parse(input));
                                    break;
                                case "6":
                                    await vacancyController.SortVacancies();
                                    break;
                                case "7":
                                    input = Console.ReadLine()!;
                                    await vacancyController.GetApplicationsForVacancy(int.Parse(input));
                                    break;
                            }
                        } while (input != "e");
                        break;
                    case "3":
                        do {
                            Console.WriteLine("1) Get field by id\n2) Get all fields\n3) Add field\n4) Edit field\ne) Exit");
                            input = Console.ReadLine()!;
                            switch (input)
                            {
                                case "1":
                                    input = Console.ReadLine()!;
                                    await fieldController.ShowField(int.Parse(input));
                                    break;
                                case "2":
                                    await fieldController.ShowAllFields();
                                    break;
                                case "3":
                                    await fieldController.AddField();
                                    break;
                                case "4":
                                    input = Console.ReadLine()!;
                                    await fieldController.EditField(int.Parse(input));
                                    break;
                            }
                        } while (input != "e");
                        break;
                    case "4":
                        do
                        {
                            Console.WriteLine("1) Create application\n2) Delete application\n3) Change application category\ne) Exit");
                            input = Console.ReadLine()!;
                            switch (input)
                            {
                                case "1":
                                    await applicationController.AddApplication();
                                    break;
                                case "2":
                                    input = Console.ReadLine()!;
                                    await applicationController.DeleteApplication(int.Parse(input));
                                    break;
                                case "3":
                                    input = Console.ReadLine()!;
                                    await applicationController.ChangeCategory(int.Parse(input));
                                    break;
                            }
                        } while (input != "e");
                        break;
                    case "5":
                        do
                        {
                            Console.WriteLine("1) Get unemployed by id\n2) Get all unemployeds\n3) Add unemployed\n4) Edit unemployed\n5) Delete unemployed\n6) Get all applications of unemployed7) Get all resumes of unemployed\n8) Search unemployed\ne) Exit");
                            input = Console.ReadLine()!;
                            switch (input)
                            {
                                case "1":
                                    input = Console.ReadLine()!;
                                    await unemployedController.ShowUnemployed(int.Parse(input));
                                    break;
                                case "2":
                                    await unemployedController.ShowAllUnemployeds();
                                    break;
                                case "3":
                                    await unemployedController.AddUnemployed();
                                    break;
                                case "4":
                                    input = Console.ReadLine()!;
                                    await unemployedController.EditUnemployed(int.Parse(input));
                                    break;
                                case "5":
                                    input = Console.ReadLine()!;
                                    await unemployedController.DeleteUnemployed(int.Parse(input));
                                    break;
                                case "6":
                                    input = Console.ReadLine()!;
                                    await unemployedController.GetApplicationsOfUnemployed(int.Parse(input));
                                    break;
                                case "7":
                                    input = Console.ReadLine()!;
                                    await unemployedController.GetResumesOfUnemployed(int.Parse(input));
                                    break;
                                case "8":
                                    input = Console.ReadLine()!;
                                    await unemployedController.Search(input);
                                    break;
                            }
                        } while (input != "e");
                        break;
                    case "6":
                        do
                        {
                            Console.WriteLine("1) Get resume by id\n2) Get all resumes\n3) Add resume\n4) Edit resume\n5) Delete resume\ne) Exit");
                            input = Console.ReadLine()!;
                            switch (input)
                            {
                                case "1":
                                    input = Console.ReadLine()!;
                                    await resumeController.ShowResume(int.Parse(input));
                                    break;
                                case "2":
                                    await resumeController.ShowAllResumes();
                                    break;
                                case "3":
                                    await resumeController.AddResume();
                                    break;
                                case "4":
                                    input = Console.ReadLine()!;
                                    await resumeController.EditResume(int.Parse(input));
                                    break;
                                case "5":
                                    input = Console.ReadLine()!;
                                    await resumeController.DeleteResume(int.Parse(input));
                                    break;
                            }
                        } while (input != "e");
                        break;
                    case "7":
                        do
                        {
                            Console.WriteLine("1) Get pending\n2) Get approved\n3) Get declined\ne) Exit");
                            input = Console.ReadLine()!;
                            switch (input)
                            {
                                case "1":
                                    await categoryController.ShowPending();
                                    break;
                                case "2":
                                    await categoryController.ShowApproved();
                                    break;
                                case "3":
                                    await categoryController.ShowDeclined();
                                    break;
                            }
                        } while (input != "e");
                        break;
                }
            } while (input != "8");
        }
    }
}