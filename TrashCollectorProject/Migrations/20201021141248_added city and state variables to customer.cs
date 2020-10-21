using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class addedcityandstatevariablestocustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24cc24db-7b4a-471b-b620-3e50742c7f19",
                column: "ConcurrencyStamp",
                value: "4c1c9a0b-e4fc-4942-b217-7424eb40ff91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30b01b69-42e6-4020-af89-c470ec2167ef",
                column: "ConcurrencyStamp",
                value: "72908849-3005-4287-9098-9385bd43ad21");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24cc24db-7b4a-471b-b620-3e50742c7f19",
                column: "ConcurrencyStamp",
                value: "91cf0f62-dd37-4632-b5f6-4215a74837be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30b01b69-42e6-4020-af89-c470ec2167ef",
                column: "ConcurrencyStamp",
                value: "c5926cfb-27be-4b02-9bf2-493a6bdfc138");
        }
    }
}
