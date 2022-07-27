using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DikaoRpgSimulator.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xp = table.Column<int>(type: "int", nullable: false),
                    XpIncrement = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MaxLife = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    DefenseHero = table.Column<int>(type: "int", nullable: false),
                    Life = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonsterEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiveXp = table.Column<int>(type: "int", nullable: false),
                    Life = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BattleData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroEntityId = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: false),
                    MonsterEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleData_HeroEntity_HeroEntityId",
                        column: x => x.HeroEntityId,
                        principalTable: "HeroEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleData_MonsterEntity_MonsterEntityId",
                        column: x => x.MonsterEntityId,
                        principalTable: "MonsterEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleData_HeroEntityId",
                table: "BattleData",
                column: "HeroEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleData_MonsterEntityId",
                table: "BattleData",
                column: "MonsterEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleData");

            migrationBuilder.DropTable(
                name: "HeroEntity");

            migrationBuilder.DropTable(
                name: "MonsterEntity");
        }
    }
}
