using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Data.Migrations
{
    public partial class updatewithidentitykeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24271c2a-ab6f-45ab-84b4-1d330d179edf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33ab04a3-709e-4cb6-a5ee-88d03df3c53d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da31afa7-d5fd-48ba-865e-a1b2f428f206", "7f0546a2-88a5-436c-80ce-2fff47e03cd9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca27ae20-3e30-4f12-bcfc-39ef3907d2bd", "21aec7a0-20e6-431e-9d0b-9696c4604d67", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca27ae20-3e30-4f12-bcfc-39ef3907d2bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da31afa7-d5fd-48ba-865e-a1b2f428f206");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33ab04a3-709e-4cb6-a5ee-88d03df3c53d", "8a94e263-57d0-4c64-b35b-811a475a9d07", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24271c2a-ab6f-45ab-84b4-1d330d179edf", "d31aaca2-1915-426b-967d-191e615454b2", "Employee", "EMPLOYEE" });
        }
    }
}
