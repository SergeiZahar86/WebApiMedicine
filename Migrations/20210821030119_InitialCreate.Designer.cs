// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiMedicine;

namespace WebApiMedicine.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20210821030119_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiMedicine.Models.Patients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Middle_name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "ул.Курако 44/26",
                            Age = 35,
                            Birth = new DateTime(1986, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "муж",
                            Middle_name = "Иванович",
                            Name = "Иван",
                            PhoneNumber = "89009546565",
                            Surname = "Иванов"
                        },
                        new
                        {
                            Id = 2,
                            Address = "ул.Новоселов 3/6",
                            Age = 55,
                            Birth = new DateTime(1966, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "муж",
                            Middle_name = "Сергеевич",
                            Name = "Николай",
                            PhoneNumber = "89505550099",
                            Surname = "Сидоров"
                        });
                });

            modelBuilder.Entity("WebApiMedicine.Models.Visits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int?>("PatientsId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsInfoKey")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("PatientsId");

                    b.ToTable("Visits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnosis = "Грипп",
                            PatientsInfoKey = 1,
                            Type = "Первичный"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2021, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnosis = "Шейный хондроз",
                            PatientsInfoKey = 2,
                            Type = "Первичный"
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnosis = "Грипп",
                            PatientsInfoKey = 1,
                            Type = "Вторичный"
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Diagnosis = "Шейный хондроз",
                            PatientsInfoKey = 2,
                            Type = "Вторичный"
                        });
                });

            modelBuilder.Entity("WebApiMedicine.Models.Visits", b =>
                {
                    b.HasOne("WebApiMedicine.Models.Patients", "Patients")
                        .WithMany("Visits")
                        .HasForeignKey("PatientsId");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("WebApiMedicine.Models.Patients", b =>
                {
                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}
