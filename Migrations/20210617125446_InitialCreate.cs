using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiMedicine.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Middle_name = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Address = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Diagnosis = table.Column<string>(type: "varchar(1000)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientsInfoKey = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "Age", "Birth", "Gender", "Middle_name", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "ул.Курако 44/26", 35, new DateTime(1986, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "муж", "Иванович", "Иван", "89009546565", "Иванов" },
                    { 2, "ул.Новоселов 3/6", 55, new DateTime(1966, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "муж", "Сергеевич", "Николай", "89505550099", "Сидоров" }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "Id", "Date", "Diagnosis", "PatientsId", "PatientsInfoKey", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Грипп", null, 1, "Первичный" },
                    { 2, new DateTime(2021, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Шейный хондроз", null, 2, "Первичный" },
                    { 3, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Грипп", null, 1, "Вторичный" },
                    { 4, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Шейный хондроз", null, 2, "Вторичный" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Id",
                table: "Patients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientsId",
                table: "Visits",
                column: "PatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
