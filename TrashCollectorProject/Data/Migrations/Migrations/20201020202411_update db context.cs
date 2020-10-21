using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class updatedbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24cc24db-7b4a-471b-b620-3e50742c7f19",
                column: "ConcurrencyStamp",
                value: "4e804351-91e9-4313-8271-ec6ac59fe79c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30b01b69-42e6-4020-af89-c470ec2167ef",
                column: "ConcurrencyStamp",
                value: "46697e28-72d5-4554-aa19-796d9aefc6da");
        }
    }
}
