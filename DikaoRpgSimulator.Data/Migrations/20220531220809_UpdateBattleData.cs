using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DikaoRpgSimulator.Data.Migrations
{
    public partial class UpdateBattleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleData_MonsterEntity_MonsterEntityId",
                table: "BattleData");

            migrationBuilder.DropIndex(
                name: "IX_BattleData_MonsterEntityId",
                table: "BattleData");

            migrationBuilder.DropColumn(
                name: "MonsterEntityId",
                table: "BattleData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonsterEntityId",
                table: "BattleData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BattleData_MonsterEntityId",
                table: "BattleData",
                column: "MonsterEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleData_MonsterEntity_MonsterEntityId",
                table: "BattleData",
                column: "MonsterEntityId",
                principalTable: "MonsterEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
