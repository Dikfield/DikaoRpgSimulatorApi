using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DikaoRpgSimulator.Data.Migrations
{
    public partial class NewGeneralUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefenseHero",
                table: "HeroEntity",
                newName: "Defense");

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "MonsterEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defense",
                table: "MonsterEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attack",
                table: "MonsterEntity");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "MonsterEntity");

            migrationBuilder.RenameColumn(
                name: "Defense",
                table: "HeroEntity",
                newName: "DefenseHero");
        }
    }
}
