using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Data.Migrations
{
    public partial class addeddaytabletogroupcustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca27ae20-3e30-4f12-bcfc-39ef3907d2bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da31afa7-d5fd-48ba-865e-a1b2f428f206");

            migrationBuilder.DropColumn(
                name: "PickupDate",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "PickupDayId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d681d510-7100-4588-9269-772d10e73e97", "c9af3c28-6ea7-4172-aacd-2a503b34cb63", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d21bae6f-863c-4e0c-9850-e80861f13aba", "ea5b8928-fc3a-4b91-93a9-7c8b9e69cd84", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PickupDayId",
                table: "Customers",
                column: "PickupDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Days_PickupDayId",
                table: "Customers",
                column: "PickupDayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Days_PickupDayId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PickupDayId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d21bae6f-863c-4e0c-9850-e80861f13aba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d681d510-7100-4588-9269-772d10e73e97");

            migrationBuilder.DropColumn(
                name: "PickupDayId",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickupDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da31afa7-d5fd-48ba-865e-a1b2f428f206", "7f0546a2-88a5-436c-80ce-2fff47e03cd9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca27ae20-3e30-4f12-bcfc-39ef3907d2bd", "21aec7a0-20e6-431e-9d0b-9696c4604d67", "Employee", "EMPLOYEE" });
        }
    }
}
