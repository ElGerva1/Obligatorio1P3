using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComiteAccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class eventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplinaID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_eventos_disciplinas_DisciplinaID",
                        column: x => x.DisciplinaID,
                        principalTable: "disciplinas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventos"
            );

           
        }
    }
}
