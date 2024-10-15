using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComiteAccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "usuarios",
                new[] { "ID", "Email", "Password", "Discriminator", "fecRegistro" },
                new object[] { 1, "admin@admin.com", "Admin.123", "Admin", DateTime.Now }
            );
            migrationBuilder.InsertData(
                "usuarios",
                new[] { "ID", "Email", "Password", "Discriminator", "fecRegistro" },
                new object[] { 2, "digitador@digitador.com", "Digitador.123", "Digitador", DateTime.Now }
            );

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
