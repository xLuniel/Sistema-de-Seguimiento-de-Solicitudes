using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolicitudesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarContenidoSolicitudATestExpediente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestExpedienteDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Folio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestExpedienteDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestExpedientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Folio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NombreSolicitante = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ContenidoSolicitud = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Solicitu__3214EC27AA69A3A2", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestExpedienteDTO");

            migrationBuilder.DropTable(
                name: "TestExpedientes");
        }
    }
}
