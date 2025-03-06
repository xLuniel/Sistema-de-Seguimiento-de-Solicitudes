using System;
using System.Collections.Generic;

namespace SolicitudesAPI.Models;

public partial class TestExpediente
{
    public int Id { get; set; }

    public string? Folio { get; set; }

    public string? NombreSolicitante { get; set; }

    public DateTime? FechaInicio { get; set; }

    public string? Estado { get; set; }

    public string? ContenidoSolicitud { get; set; }
}
