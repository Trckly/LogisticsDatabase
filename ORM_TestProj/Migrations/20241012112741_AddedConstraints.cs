using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORM_TestProj.Migrations
{
    /// <inheritdoc />
    public partial class AddedConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LicensePlate",
                table: "Vehicles",
                type: "character(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8)",
                oldMaxLength: 8);

            migrationBuilder.CreateIndex(
                name: "IX_Logists_FirstName_LastName_Surname",
                table: "Logists",
                columns: new[] { "FirstName", "LastName", "Surname" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Logists_FirstName_LastName_Surname",
                table: "Logists");

            migrationBuilder.AlterColumn<string>(
                name: "LicensePlate",
                table: "Vehicles",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(8)",
                oldFixedLength: true,
                oldMaxLength: 8);
        }
    }
}
