using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComiteAccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "disciplinas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplinas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "paises",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadHabitantes = table.Column<int>(type: "int", nullable: false),
                    NombreContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoContacto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paises", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    fecRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.ID);
                });



            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_eventos_disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "disciplinas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "atletas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    DisciplinasIds = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue:"[]"),
                    EventoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atletas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_atletas_eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "eventos",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_atletas_paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "paises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
            name: "AtletaDisciplina",
            columns: table => new
            {
                AtletasID = table.Column<int>(type: "int", nullable: false),
                DisciplinasID = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AtletaDisciplina", x => new { x.AtletasID, x.DisciplinasID });
                table.ForeignKey(
                    name: "FK_AtletaDisciplina_atletas_AtletasID",
                    column: x => x.AtletasID,
                    principalTable: "atletas",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AtletaDisciplina_disciplinas_DisciplinasID",
                    column: x => x.DisciplinasID,
                    principalTable: "disciplinas",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Cascade);
            });


            migrationBuilder.CreateTable(
                name: "eventosAtletas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    AtletaId = table.Column<int>(type: "int", nullable: false),
                    Puntaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventosAtletas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_eventosAtletas_atletas_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "atletas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventosAtletas_eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "eventos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_atletas_EventoID",
                table: "atletas",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_eventosAtletas_AtletaId",
                table: "eventosAtletas",
                column: "AtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_eventosAtletas_EventoId",
                table: "eventosAtletas",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtletaDisciplina_DisciplinasID",
                table: "AtletaDisciplina",
                column: "DisciplinasID");

            migrationBuilder.CreateIndex(
                name: "IX_atletas_PaisId",
                table: "atletas",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Email",
                table: "usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaDisciplina");

            migrationBuilder.DropTable(
                name: "eventosAtletas");

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
