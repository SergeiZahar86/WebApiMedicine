using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiMedicine.Models;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace WebApiMedicine
{
    public partial class EntityContext : DbContext
    {
       /* public EntityContext()
        {
        }*/
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Visits> Visits { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 11)));
                
                optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientsConfiguration());
            modelBuilder.ApplyConfiguration(new VisitsConfiguration());
        }
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information).AddProvider(new MyLoggerProvider());
        });

    }
}
