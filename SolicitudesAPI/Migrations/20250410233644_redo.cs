using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolicitudesAPI.Migrations
{
    /// <inheritdoc />
    public partial class redo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Folio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MesAdmision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoSolicitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDerecho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreSolicitante = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaLimiteRespuesta10dias = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ampliacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSesionComiteAmpliacion = table.Column<int>(type: "int", nullable: false),
                    FechaSesionComiteAmpliacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaLimiteRespuesta20dias = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PromedioDiasRespuesta = table.Column<int>(type: "int", nullable: false),
                    Prevencion = table.Column<bool>(type: "bit", nullable: false),
                    SubsanaPrevencion_ReinicoTramite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaLimitePrevencion10dias = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecibidaRegistrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedioRecepcionSolicitudManual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComoDeseaRecibirRespuestaPersonaSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronicoSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContenidoSolicitud = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AreaPoseedoraInformacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Materia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tematica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TematicaEspecifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentidoRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecisionSentidoRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModalidadEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cobro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecursoRevision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroRecursoRevision = table.Column<int>(type: "int", nullable: false),
                    DatosRecursoRevision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Expedientes");
        }
    }
}
