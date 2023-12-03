using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWeb.Migrations
{
    /// <inheritdoc />
    public partial class updatecontacttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subject",
                table: "tbl_contact",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tbl_contact",
                newName: "OpeningTimings");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "tbl_contact",
                newName: "OpeningDays");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "tbl_contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClosedDays",
                table: "tbl_contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "tbl_chefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "tbl_contact");

            migrationBuilder.DropColumn(
                name: "ClosedDays",
                table: "tbl_contact");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "tbl_contact",
                newName: "subject");

            migrationBuilder.RenameColumn(
                name: "OpeningTimings",
                table: "tbl_contact",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OpeningDays",
                table: "tbl_contact",
                newName: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "tbl_chefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
