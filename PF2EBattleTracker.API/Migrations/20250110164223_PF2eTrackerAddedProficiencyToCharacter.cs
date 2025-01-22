using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF2EBattleTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class PF2eTrackerAddedProficiencyToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "ProficiencyId", "Description", "Stat", "Level", "Type", "LoreSkill", "CharacterId" },
                values: new object[] { 1, "Fortitude", "Constitution", 0, 2, false, 1 });

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "ProficiencyId", "Description", "Stat", "Level", "Type", "LoreSkill", "CharacterId" },
                values: new object[] { 2, "Reflex", "Dexterity", 0, 2, false, 1 });

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "ProficiencyId", "Description", "Stat", "Level", "Type", "LoreSkill", "CharacterId" },
                values: new object[] { 3, "Will", "Wisdom", 0, 2, false, 1 });

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "ProficiencyId", "Description", "Stat", "Level", "Type", "LoreSkill", "CharacterId" },
                values: new object[] { 4, "Fortitude", "Constitution", 0, 2, false, 2 });

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "ProficiencyId", "Description", "Stat", "Level", "Type", "LoreSkill", "CharacterId" },
                values: new object[] { 5, "Reflex", "Dexterity", 0, 2, false, 2 });

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "ProficiencyId", "Description", "Stat", "Level", "Type", "LoreSkill", "CharacterId" },
                values: new object[] { 6, "Will", "Wisdom", 0, 2, false, 2 });

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "ProficiencyId", "Description", "Stat", "Level", "Type", "LoreSkill", "CharacterId" },
                values: new object[] { 7, "Fortitude", "Constitution", 0, 2, false, 3 });

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "ProficiencyId", "Description", "Stat", "Level", "Type", "LoreSkill", "CharacterId" },
                values: new object[] { 8, "Reflex", "Dexterity", 0, 2, false, 3 });

            migrationBuilder.InsertData(
                table: "Proficiencies",
                columns: new[] { "ProficiencyId", "Description", "Stat", "Level", "Type", "LoreSkill", "CharacterId" },
                values: new object[] { 9, "Will", "Wisdom", 0, 2, false, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Proficiencies", true);


        }
    }
}
