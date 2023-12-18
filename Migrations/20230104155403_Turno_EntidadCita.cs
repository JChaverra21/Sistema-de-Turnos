using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turno.Migrations
{
    public partial class Turno_EntidadCita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    IdCita = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(unicode: false, nullable: false),
                    IdMedico = table.Column<int>(unicode: false, nullable: false),
                    FechaHoraInicio = table.Column<DateTime>(unicode: false, nullable: false),
                    FechaHoraFin = table.Column<DateTime>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Cita_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdMedico",
                table: "Cita",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdPaciente",
                table: "Cita",
                column: "IdPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");
        }
    }
}
