using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newsite.Migrations
{
    /// <inheritdoc />
    public partial class SubmittedBy2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubmittedBy",
                table: "Employees",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmittedBy",
                table: "Employees");
        }
    }
}
