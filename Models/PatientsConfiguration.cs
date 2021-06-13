using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace WebApiMedicine.Models
{
    public class PatientsConfiguration : IEntityTypeConfiguration<Patients>
    {
        public void Configure(EntityTypeBuilder<Patients> builder)
        {
            builder.HasIndex(u => u.Id);
            //builder.Property(u => u.FullName).HasComputedColumnSql("[Surname] + ' ' + [Name] + ' ' + [MiddleName]");
            builder.HasData(
            new Patients[]
            {
                new Patients { Id=1, Surname = "Иванов", Name="Иван", Middle_name="Иванович",
                    Birth = new DateTime(1986,4,22), Gender="муж", Adress="ул.Курако 44/26",
                    PhoneNumber = "89009546565",  Age=35},
                new Patients { Id=2, Surname = "Сидоров", Name="Николай", Middle_name="Сергеевич",
                    Birth = new DateTime(1966,6,10), Gender="муж", Adress="ул.Новоселов 3/6",
                    PhoneNumber = "89505550099",  Age=55},
            });
        }
    }
}
