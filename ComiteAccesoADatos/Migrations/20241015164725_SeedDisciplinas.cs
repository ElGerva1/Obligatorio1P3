using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComiteAccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class SeedDisciplinas : Migration
    {
        /// <inheritdoc />

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 1, "Balonmano", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 2, "Surf", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 3, "Taekwondo", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 4, "Tenis", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 5, "Tenis de mesa", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 6, "Tiro", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 7, "Tiro con arco", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 8, "Triatlón", 94 }
            );

            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 9, "Vela", 94 }
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
