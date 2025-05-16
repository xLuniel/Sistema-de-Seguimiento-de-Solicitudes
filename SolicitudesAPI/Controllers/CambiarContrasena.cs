namespace Sistema_de_Seguimiento_de_Solicitudes.Models
{
    public class CambiarContrasena
    {
        public class CambiarContrasenaRequest
        {
            public int UsuarioId { get; set; }
            public string NuevaContrasena { get; set; } = string.Empty;
        }

    }
}
