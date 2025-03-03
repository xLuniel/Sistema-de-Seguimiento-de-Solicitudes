namespace Sistema_de_Seguimiento_de_Solicitudes.Models
{
    public class Expediente
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public string MesAdmision { get; set; }
        public string TipoSolicitud { get; set; }
        public string TipoDerecho { get; set; }
        public DateTime FechaInicioTramite { get; set; }
        public DateTime FechaLimiteRespuesta10 { get; set; }
        public string Ampliacion { get; set; }
        public DateTime FechaLimiteRespuesta20 { get; set; }
        public string Estatus { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public int PromedioDiasRespuesta { get; set; }
        public string Prevention { get; set; }
        public string SubsanaPrevencion { get; set; }
        public DateTime FechaLimitePrevencion { get; set; }
        public string RecibidaRegistrada { get; set; }
        public string ComoDeseaRecibirRespuestaPersonaSolicitante { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string ContenidoSolicitud { get; set; }
        public string AreaInformacion { get; set; }
        public string Materia { get; set; }
        public string Ciudad { get; set; }
        public string Tematica { get; set; }
        public string TematicaEspecifica { get; set; }
        public string SentidoRespuesta { get; set; }
        public string PrecisionSentidoRespuesta { get; set; }
        public string ModalidadEntrega { get; set; }
        public string Cobro { get; set; }
        public string RecursoRevision { get; set; }
        public string DatosRecursoRevision { get; set; }
        public string Nota { get; set; }
    }
}
