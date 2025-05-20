namespace Sistema_de_Seguimiento_de_Solicitudes.Models
{
    public class EventoSolicitud
    {
        public string Title { get; set; } = "";
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string TipoSolicitud { get; set; } = "";
        public bool TienePrevencion { get; set; }
        public bool EsUrgente { get; set; }
    }
}
