using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF2EBattleTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class PF2eTrackerAddedSaveParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SaveDC",
                table: "Proficiencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 1,
                columns: new[] { "SaveDC", "Level"},
                values: new object[] { true, 4});

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 2,
                columns: new[] { "SaveDC", "Level" },
                values: new object[] { true, 4});

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 3,
                columns: new[] { "SaveDC", "Level" },
                values: new object[] { true, 2});

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 4,
                columns: new[] { "SaveDC", "Level" },
                values: new object[] { true, 2});

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 5,
                columns: new[] { "SaveDC", "Level" },
                values: new object[] { true, 4});

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 6,
                columns: new[] { "SaveDC", "Level" },
                values: new object[] { true, 4});

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 7,
                columns: new[] { "SaveDC", "Level" },
                values: new object[] { true, 2});

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 8,
                columns: new[] { "SaveDC", "Level" },
                values: new object[] { true, 4});

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 9,
                columns: new[] { "SaveDC", "Level" },
                values: new object[] { true, 4});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaveDC",
                table: "Proficiencies");

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 1,
                columns: new[] {"Level" },
                values: new object[] { 0 });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 2,
                columns: new[] { "Level" },
                values: new object[] { 0 });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 3,
                columns: new[] { "Level" },
                values: new object[] { 0 });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 4,
                columns: new[] { "Level" },
                values: new object[] { 0 });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 5,
                columns: new[] { "Level" },
                values: new object[] { 0 });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 6,
                columns: new[] { "Level" },
                values: new object[] { 0 });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 7,
                columns: new[] { "Level" },
                values: new object[] { 0 });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 8,
                columns: new[] { "Level" },
                values: new object[] { 0 });

            migrationBuilder.UpdateData(
                table: "Proficiencies",
                keyColumn: "ProficiencyId",
                keyValue: 9,
                columns: new[] { "Level" },
                values: new object[] { 0 });
        }
    }
}
