using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCLab8.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerGenderToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add temporary int column
            migrationBuilder.AddColumn<int>(
                name: "GenderTemp",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Map existing string values to ints (male -> 0, female -> 1). Use LOWER for robustness.
            migrationBuilder.Sql(
                "UPDATE [Customers] SET GenderTemp = CASE WHEN LOWER([Gender]) IN ('male','m') THEN 0 WHEN LOWER([Gender]) IN ('female','f') THEN 1 ELSE 0 END;");

            // Drop old string column
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            // Rename temp column to Gender
            migrationBuilder.RenameColumn(
                name: "GenderTemp",
                table: "Customers",
                newName: "Gender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Add temporary string column
            migrationBuilder.AddColumn<string>(
                name: "GenderTemp",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Male");

            // Map enum ints back to string values
            migrationBuilder.Sql(
                "UPDATE [Customers] SET GenderTemp = CASE WHEN [Gender] = 0 THEN 'Male' WHEN [Gender] = 1 THEN 'Female' ELSE 'Male' END;");

            // Drop int column
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            // Rename temp string back to Gender
            migrationBuilder.RenameColumn(
                name: "GenderTemp",
                table: "Customers",
                newName: "Gender");
        }
    }
}
