using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairShopProject.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    licensePlate = table.Column<string>(nullable: true),
                    brand = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    modelYear = table.Column<string>(nullable: true),
                    customerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    vehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Appointments_Vehicles_vehicleId",
                        column: x => x.vehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "IsRemoved", "email", "fullName", "phoneNumber" },
                values: new object[,]
                {
                    { 1, true, "deneme@gmail.com", "Ali", "0534 123 4567" },
                    { 2, true, "deneme@gmail.com", "Merve", "0534 123 4567" },
                    { 3, false, "deneme@gmail.com", "Aslı", "0534 123 4567" },
                    { 4, false, "deneme@gmail.com", "Kemal", "0534 123 4567" },
                    { 5, true, "test@gmail.com", "Ayşe", "0534 987 6543" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "id", "brand", "customerId", "licensePlate", "model", "modelYear" },
                values: new object[,]
                {
                    { 1, "BMW", 1, "34 KLC 1234", "i7", "2020" },
                    { 2, "Renault", 2, "42 MNP 1583", "Clio", "2018" },
                    { 3, "Audi", 3, "34 JLG 5306", "A3", "2017" },
                    { 4, "Audi", 4, "34 JLG 5306", "A3", "2017" },
                    { 5, "Audi", 5, "34 JLG 5306", "A3", "2017" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "id", "date", "vehicleId" },
                values: new object[] { 1, new DateTime(2021, 8, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "id", "date", "vehicleId" },
                values: new object[] { 2, new DateTime(2021, 2, 21, 15, 30, 30, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_vehicleId",
                table: "Appointments",
                column: "vehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_customerId",
                table: "Vehicles",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
