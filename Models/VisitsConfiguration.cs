using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace WebApiMedicine.Models
{
    public class VisitsConfiguration : IEntityTypeConfiguration<Visits>
    {
        public void Configure(EntityTypeBuilder<Visits> builder)
        {
            builder.HasData(
            new Visits[]
            {
                new Visits { Id=1, Date = new DateTime(2021,5,22), Type="Первичный",
                    Diagnosis="Грипп", PatientsInfoKey = 1},
                new Visits { Id=2, Date = new DateTime(2021,6,2), Type="Первичный",
                    Diagnosis="Шейный хондроз", PatientsInfoKey = 2},
                new Visits { Id=3, Date = new DateTime(2021,5,24), Type="Вторичный",
                    Diagnosis="Грипп", PatientsInfoKey = 1},
                new Visits { Id=4, Date = new DateTime(2021,6,5), Type="Вторичный",
                    Diagnosis="Шейный хондроз", PatientsInfoKey = 2},
            });
        }
    }
}
