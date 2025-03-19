using System;
using System.Collections.Generic;

namespace SolicitudesAPI.Models;

public partial class Expediente
{
    //Etapa Final
    public int Id { get; set; }
    public string? Folio { get; set; }
    public string? MesAdmision { get; set; }
    public string? TipoSolicitud { get; set; }
    public string? TipoDerecho { get; set; }
    public string? NombreSolicitante { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaLimiteRespuesta10dias { get; set; }
    public string? Ampliacion { get; set; }
    public DateTime? FechaLimiteRespuesta20dias { get; set; }
    public string? Estado { get; set; }
    public string? FechaRespuesta { get; set; }
    public string? Prevencion { get; set; }

    public string? SubsanaPrevencionReinicoTramite { get; set; }
    public string? FechaLimitePrevencion10dias { get; set; }
    public string? PreferenciaParaRecibirRespuesta { get; set; }
    public string? CorreoElectronicoSolicitante { get; set; }
    public string? ContenidoSolicitud { get; set; }


    //Etapa de Seguimiento
    public string? AreaPoseedoraInformacion { get; set; }


    //Etapa Final
    public string? Materia { get; set; }
    public string? CiudadSolicitante { get; set; }
    public string? Tematica { get; set; }
    public string? TematicaEspecifica { get; set; }
    public string? SentidoRespuesta { get; set; }
    public string? PrecisionSentidoRespuesta { get; set; }
    public string? ModalidadEntrega { get; set; }

    public string? Cobro { get; set; }
    public string? RecursoRevision { get; set; }
    public string? DatosRecursoRevision { get; set; }
    public string? Nota { get; set; }
}
