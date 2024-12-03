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

            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 10, "Atletismo", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 11, "Ciclismo", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 12, "Natación", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 13, "Gimnasia", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 14, "Boxeo", 94 }
            );
            migrationBuilder.InsertData(
                "disciplinas",
                new[] { "ID", "Nombre", "Year" },
                new object[] { 15, "Esgrima", 94 }
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
