using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NouveauSellix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUserColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TB_UsersData",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TB_UsersData");
        }
    }
}
