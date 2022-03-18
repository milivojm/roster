using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster.Api.Migrations
{
    public partial class Accepted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "MembershipApplications",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "MembershipApplications");
        }
    }
}
