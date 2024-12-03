using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComiteAccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class seedEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "ID", "DisciplinaId", "Nombre", "Inicio", "Fin" },
                values: new object[,]
                {
                    { 1, 1, "Evento Balonmano", new DateTime(2024, 5, 1), new DateTime(2024, 5, 2) },   
                    { 2, 2, "Evento Surf", new DateTime(2024, 6, 15), new DateTime(2024, 6, 16) },
                    { 3, 1, "Evento Balonmano", new DateTime(2024, 5, 1), new DateTime(2024, 5, 2) },
                    { 4, 2, "Evento Surf", new DateTime(2024, 6, 15), new DateTime(2024, 6, 16) },
                    { 5, 1, "Evento Balonmano", new DateTime(2024, 5, 1), new DateTime(2024, 5, 2) },
                    { 6, 2, "Evento Surf", new DateTime(2024, 6, 15), new DateTime(2024, 6, 16) },
                    { 7, 1, "Evento Balonmano", new DateTime(2024, 5, 1), new DateTime(2024, 5, 2) },
                    { 8, 2, "Evento Surf", new DateTime(2024, 6, 15), new DateTime(2024, 6, 16) },
                    { 9, 3, "Evento Taekwondo", new DateTime(2024, 5, 1), new DateTime(2024, 5, 2) },
                    { 10, 3, "Evento Taekwondo", new DateTime(2024, 6, 15), new DateTime(2024, 6, 16) },
                    { 11, 3, "Evento Taekwondo", new DateTime(2024, 5, 1), new DateTime(2024, 5, 2) },
                    { 12, 3, "Evento Taekwondo", new DateTime(2024, 6, 15), new DateTime(2024, 6, 16) },
                    { 13, 3, "Evento Taekwondo", new DateTime(2024, 5, 1), new DateTime(2024, 5, 2) },
                    { 14, 4, "Evento Tenis", new DateTime(2024, 6, 15), new DateTime(2024, 6, 16) },
                    { 15, 4, "Evento Tenis", new DateTime(2024, 5, 1), new DateTime(2024, 5, 2) },
                    { 16, 4, "Evento Tenis", new DateTime(2024, 6, 15), new DateTime(2024, 6, 16) },
                    { 17, 4, "Evento Tenis", new DateTime(2024, 5, 1), new DateTime(2024, 5, 2) },
                    { 18, 4, "Evento Tenis", new DateTime(2024, 6, 15), new DateTime(2024, 6, 16) }

                });

            // Insertar datos en la tabla de EventoAtleta (relación muchos a muchos)
            migrationBuilder.InsertData(
            table: "eventosAtletas",
            columns: new[] { "ID", "EventoId", "AtletaId", "Puntaje" },
            values: new object[,]
            {
                // Evento 1
                { 1, 1, 1, 95.5m },
                { 2, 1, 2, 92.3m },

                // Evento 2
                { 3, 2, 1, 89.1m },
                { 4, 2, 3, 91.7m },

                // Evento 3
                { 5, 3, 4, 88.4m },
                { 6, 3, 5, 93.0m },

                // Evento 4
                { 7, 4, 6, 85.7m },
                { 8, 4, 7, 90.6m },

                // Evento 5
                { 9, 5, 8, 92.1m },
                { 10, 5, 9, 87.3m },

                // Evento 6
                { 11, 6, 10, 94.4m },
                { 12, 6, 11, 88.9m },

                // Evento 7
                { 13, 7, 12, 91.5m },
                { 14, 7, 13, 89.2m },

                // Evento 8
                { 15, 8, 14, 90.1m },
                { 16, 8, 15, 93.3m },

                // Evento 9
                { 17, 9, 16, 87.9m },
                { 18, 9, 17, 86.5m },

                // Evento 10
                { 19, 10, 18, 91.7m },
                { 20, 10, 19, 95.0m },

                // Evento 11
                { 21, 11, 20, 94.8m },
                { 22, 11, 21, 92.6m },

                // Evento 12
                { 23, 12, 1, 89.4m },
                { 24, 12, 2, 91.2m },

                // Evento 13
                { 25, 13, 3, 87.6m },
                { 26, 13, 4, 90.3m },

                // Evento 14
                { 27, 14, 5, 92.0m },
                { 28, 14, 6, 85.8m },

                // Evento 15
                { 29, 15, 7, 88.1m },
                { 30, 15, 8, 93.5m },

                // Evento 16
                { 31, 16, 9, 90.7m },
                { 32, 16, 10, 91.3m },

                // Evento 17
                { 33, 17, 11, 93.4m },
                { 34, 17, 12, 85.6m },

                // Evento 18
                { 35, 18, 13, 87.2m },
                { 36, 18, 14, 92.8m }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaDisciplina");

            migrationBuilder.DropTable(
                name: "eventosAtletas");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "atletas");

            migrationBuilder.DropTable(
                name: "eventos");

            migrationBuilder.DropTable(
                name: "paises");

            migrationBuilder.DropTable(
                name: "disciplinas");
        }
    }
}
