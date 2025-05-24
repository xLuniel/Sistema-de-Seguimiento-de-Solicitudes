using System;
using System.Collections.Generic;

namespace SolicitudesAPI.Models;

public partial class Calendario
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public bool Activo { get; set; }
}


