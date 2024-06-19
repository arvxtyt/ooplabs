using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using System.Configuration;


namespace DataAccessLayer.Data
{
    public class JobCentreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\epamdotnet\\JobCenter\\DataAccessLayer\\Local.db");
        }

        public DbSet<Firm> Firms { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Unemployed> Unemployeds { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}
