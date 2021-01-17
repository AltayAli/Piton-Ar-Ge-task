using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TaskManager.Data.Models;

namespace TaskManager.Data.Datas
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base() { }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TaskManagerContext");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
