namespace Sistema_de_Seguimiento_de_Solicitudes.Models
{
    public class Expediente
    {
        public int Id { get; set; }
        public string Folio { get; set; } = string.Empty;
        public string MesAdmision { get; set; } = string.Empty;
        public string TipoSolicitud { get; set; } = string.Empty;
        public string TipoDerecho { get; set; } = string.Empty;
        public DateTime FechaInicioTramite { get; set; }
        public DateTime? FechaLimiteRespuesta10 { get; set; }
        public string Ampliacion { get; set; } = string.Empty;
        public DateTime? FechaLimiteRespuesta20 { get; set; }
        public string Estatus { get; set; } = string.Empty;
        public DateTime FechaRespuesta { get; set; }
        public int PromedioDiasRespuesta { get; set; }
        public bool Prevencion { get; set; } = false;
        public string SubsanaPrevencion { get; set; } = string.Empty;
        public DateTime FechaLimitePrevencion { get; set; }
        public string RecibidaRegistrada { get; set; } = string.Empty;
        public string ComoDeseaRecibirRespuestaPersonaSolicitante { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public string ContenidoSolicitud { get; set; } = string.Empty;
        public string AreaInformacion { get; set; } = string.Empty;
        public string Materia { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Tematica { get; set; } = string.Empty;
        public string TematicaEspecifica { get; set; } = string.Empty;
        public string SentidoRespuesta { get; set; } = string.Empty;
        public string PrecisionSentidoRespuesta { get; set; } = string.Empty;
        public string ModalidadEntrega { get; set; } = string.Empty;
        public string Cobro { get; set; } = string.Empty;
        public string RecursoRevision { get; set; } = string.Empty;
        public string DatosRecursoRevision { get; set; } = string.Empty;
        public string Nota { get; set; } = string.Empty;

        // Constructor
        public Expediente()
        {
            // Inicializar con la fecha y hora actual
            FechaInicioTramite = DateTime.Now;
            //FechaLimiteRespuesta10 = DateTime.Now;
            //FechaLimiteRespuesta20 = DateTime.Now;
            FechaRespuesta = DateTime.Now;
            FechaLimitePrevencion = DateTime.Now;
        }
    }
}