using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class updatedlatitudeandlongitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Longitute",
                table: "Customers");

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Customers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24cc24db-7b4a-471b-b620-3e50742c7f19",
                column: "ConcurrencyStamp",
                value: "aadb41d4-0b31-440f-8377-a9186cc62be0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30b01b69-42e6-4020-af89-c470ec2167ef",
                column: "ConcurrencyStamp",
                value: "d48b8f6f-c2de-4e9b-9bbb-c80918fe4915");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Customers");

            migrationBuilder.AddColumn<double>(
                name: "Longitute",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24cc24db-7b4a-471b-b620-3e50742c7f19",
                column: "ConcurrencyStamp",
                value: "d807560f-f636-45ef-a39a-5036635b0094");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30b01b69-42e6-4020-af89-c470ec2167ef",
                column: "ConcurrencyStamp",
                value: "89d96980-0396-4cee-8227-1407fa451399");
        }
    }
}
