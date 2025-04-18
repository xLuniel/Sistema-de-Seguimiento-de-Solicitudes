using System;
using System.Collections.Generic;

namespace SolicitudesAPI.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string password { get; set; } = null!;

    public string Rol { get; set; } = null!;
}
