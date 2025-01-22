using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF2EBattleTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class PF2eTrackerChangedStatToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 1,
                columns: new[] { "Stat"},
                values: new object[] {"2"});

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 2,
                columns: new[] { "Stat" },
                values: new object[] { "1" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 3,
                columns: new[] { "Stat" },
                values: new object[] { "4" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 4,
                columns: new[] { "Stat" },
                values: new object[] { "2" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 5,
                columns: new[] { "Stat" },
                values: new object[] { "1" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 6,
                columns: new[] { "Stat" },
                values: new object[] { "4" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 7,
                columns: new[] { "Stat" },
                values: new object[] { "2" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 8,
                columns: new[] { "Stat" },
                values: new object[] { "1" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 9,
                columns: new[] { "Stat" },
                values: new object[] { "4" });

            migrationBuilder.RenameColumn(
                name: "LoreSkill",
                table: "Proficiencies",
                newName: "DefaultSkill");

            migrationBuilder.AlterColumn<int>(
                name: "Stat",
                table: "Proficiencies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultSkill",
                table: "Proficiencies",
                newName: "LoreSkill");

            migrationBuilder.AlterColumn<string>(
                name: "Stat",
                table: "Proficiencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 1,
                columns: new[] { "Stat" },
                values: new object[] { "Constitution" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 2,
                columns: new[] { "Stat" },
                values: new object[] { "Dexterity" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 3,
                columns: new[] { "Stat" },
                values: new object[] { "Wisdom" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 4,
                columns: new[] { "Stat" },
                values: new object[] { "Constitution" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 5,
                columns: new[] { "Stat" },
                values: new object[] { "Dexterity" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 6,
                columns: new[] { "Stat" },
                values: new object[] { "Wisdom" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 7,
                columns: new[] { "Stat" },
                values: new object[] { "Constitution" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 8,
                columns: new[] { "Stat" },
                values: new object[] { "Dexterity" });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 9,
                columns: new[] { "Stat" },
                values: new object[] { "Wisdom" });

        }
    }
}
