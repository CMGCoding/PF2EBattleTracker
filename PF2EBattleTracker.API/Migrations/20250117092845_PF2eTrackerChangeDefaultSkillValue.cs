using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF2EBattleTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class PF2eTrackerChangeDefaultSkillValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 1,
                columns: new[] { "DefaultSkill" },
                values: new object[] { true });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 2,
                columns: new[] { "DefaultSkill" },
                values: new object[] { true });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 3,
                columns: new[] { "DefaultSkill" },
                values: new object[] { true });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 4,
                columns: new[] { "DefaultSkill" },
                values: new object[] { true });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 5,
                columns: new[] { "DefaultSkill" },
                values: new object[] { true });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 6,
                columns: new[] { "DefaultSkill" },
                values: new object[] { true });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 7,
                columns: new[] { "DefaultSkill" },
                values: new object[] { true });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 8,
                columns: new[] { "DefaultSkill" },
                values: new object[] { true });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 9,
                columns: new[] { "DefaultSkill" },
                values: new object[] { true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 1,
                columns: new[] { "DefaultSkill" },
                values: new object[] { false });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 2,
                columns: new[] { "DefaultSkill" },
                values: new object[] { false });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 3,
                columns: new[] { "DefaultSkill" },
                values: new object[] { false });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 4,
                columns: new[] { "DefaultSkill" },
                values: new object[] { false });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 5,
                columns: new[] { "DefaultSkill" },
                values: new object[] { false });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 6,
                columns: new[] { "DefaultSkill" },
                values: new object[] { false });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 7,
                columns: new[] { "DefaultSkill" },
                values: new object[] { false });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 8,
                columns: new[] { "DefaultSkill" },
                values: new object[] { false });
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 9,
                columns: new[] { "DefaultSkill" },
                values: new object[] { false });
        }
    }
}
