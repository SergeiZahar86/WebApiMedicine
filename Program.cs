using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiMedicine.Models;

namespace WebApiMedicine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<EntityContext>();
            var options = optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 19))).Options;

            using (EntityContext db = new EntityContext(options))
            {
                var patients = db.Patients.ToList();
                foreach (Patients pat in patients)
                {
                    Console.WriteLine($"{pat.Id}.{pat.FullName} - {pat.Age}");
                }
            }
            Console.Read();*/



            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
