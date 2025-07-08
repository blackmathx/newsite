using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newsite.Migrations
{
    /// <inheritdoc />
    public partial class SubmissionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmittedOn",
                table: "Submissions",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Submissions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Submissions",
                newName: "SubmittedOn");
        }
    }
}
