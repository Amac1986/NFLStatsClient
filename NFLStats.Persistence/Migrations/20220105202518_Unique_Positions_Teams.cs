using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFLStats.Persistence.Migrations
{
    public partial class Unique_Positions_Teams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionName",
                table: "Positions");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name",
                table: "Teams",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PostionCode",
                table: "Positions",
                column: "PostionCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_Name",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Positions_PostionCode",
                table: "Positions");

            migrationBuilder.AddColumn<string>(
                name: "PositionName",
                table: "Positions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
