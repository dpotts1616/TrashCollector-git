using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class addedaddressproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b911db0-2f85-4e8c-ba8d-abecc2b8d623");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bec71345-8731-4369-bad2-f985eb5abe4a");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24cc24db-7b4a-471b-b620-3e50742c7f19", "4e804351-91e9-4313-8271-ec6ac59fe79c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30b01b69-42e6-4020-af89-c470ec2167ef", "46697e28-72d5-4554-aa19-796d9aefc6da", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24cc24db-7b4a-471b-b620-3e50742c7f19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30b01b69-42e6-4020-af89-c470ec2167ef");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bec71345-8731-4369-bad2-f985eb5abe4a", "8336804c-ba61-4c31-ac38-b06db558dc73", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b911db0-2f85-4e8c-ba8d-abecc2b8d623", "55b079ad-70ea-4c61-a9bc-49e5e4d7c234", "Employee", "EMPLOYEE" });
        }
    }
}
