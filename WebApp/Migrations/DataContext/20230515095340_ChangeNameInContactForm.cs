using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations.DataContext
{
    /// <inheritdoc />
    public partial class ChangeNameInContactForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ContactForms");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "ContactForms",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ContactForms",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ContactForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
