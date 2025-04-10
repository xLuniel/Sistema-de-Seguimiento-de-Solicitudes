using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SolicitudesShared
{
    public class ExpedienteDTO
    {
        // --------------------------------------------------------------------------------- Etapa Inicial
        // Identificador del expediente
        public int Id { get; set; }

        // Número de la solicitud
        public string? Folio { get; set; }

        // Año de admisión
        public int AnoAdmision { get; set; }

        // Mes de admisión
        public string? MesAdmision { get; set; }

        // Tipo de solicitud
        public string? TipoSolicitud { get; set; }

        // Tipo de derecho
        public string? TipoDerecho { get; set; }

        // Nombre del solicitante
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? NombreSolicitante { get; set; }

        // Fecha de inicio del trámite
        public DateTime FechaInicio { get; set; }

        // Fecha límite de respuesta (10 días hábiles)
        public DateTime? FechaLimiteRespuesta10dias { get; set; }

        // Indica si hubo una ampliación
        public string? Ampliacion { get; set; }

        // Número de la sesión del Comité que confirma la ampliación
        public int NumeroSesionComiteAmpliacion { get; set; }

        // Fecha de la sesión del Comité que confirma la ampliación
        public DateTime? FechaSesionComiteAmpliacion { get; set; }

        // Fecha límite de respuesta (20 días hábiles)
        public DateTime? FechaLimiteRespuesta20dias { get; set; }

        // Estado del expediente
        public string? Estado { get; set; }

        // Fecha de respuesta de la solicitud
        public DateTime? FechaRespuesta { get; set; }

        // Promedio de días de respuesta
        public int PromedioDiasRespuesta { get; set; }

        // Indica si hubo prevención en la solicitud
        public bool Prevencion { get; set; } = false;

        // Información sobre la subsanación de la prevención y reinicio del trámite
        public string? SubsanaPrevencionReinicoTramite { get; set; }

        // Fecha límite para subsanar la prevención
        public DateTime? FechaLimitePrevencion10dias { get; set; }

       // public string? PreferenciaParaRecibirRespuesta { get; set; }

        // Cómo fue recibida o registrada la solicitud en la PNT
        public string? RecibidaRegistrada { get; set; }

        // Medio de recepción en solicitud manual
        public string? MedioRecepcionSolicitudManual { get; set; }

        // Cómo desea recibir la respuesta la persona solicitante
        public string? ComoDeseaRecibirRespuestaPersonaSolicitante { get; set; }

        // Correo electrónico del solicitante
        public string? CorreoElectronicoSolicitante { get; set; }

        // Contenido de la solicitud
        public string? ContenidoSolicitud { get; set; }



        // ---------------------------------------------------------------------------------Etapa de Seguimiento
        // Área que posee la información
        public string? AreaPoseedoraInformacion { get; set; }



        // --------------------------------------------------------------------------------- Etapa Final
        // Materia de la solicitud
        public string? Materia { get; set; }

        // Ciudad del solicitante
        public string? CiudadSolicitante { get; set; }

        // Temática de la solicitud
        public string? Tematica { get; set; }

        // Temática específica de la solicitud
        public string? TematicaEspecifica { get; set; }

        // Sentido de la respuesta
        public string? SentidoRespuesta { get; set; }

        // Precisión del sentido de la respuesta
        public string? PrecisionSentidoRespuesta { get; set; }

        // Modalidad de entrega de la respuesta
        public string? ModalidadEntrega { get; set; }

        // Cobro asociado a la solicitud
        public string? Cobro { get; set; }

        // Indica si hay un recurso de revisión
        public string? RecursoRevision { get; set; }

        // Número de recurso de revisión
        public int NumeroRecursoRevision { get; set; }

        // Datos del recurso de revisión
        public string? DatosRecursoRevision { get; set; }

        // Nota adicional sobre el expediente
        public string? Nota { get; set; }


        public ExpedienteDTO()
        {
            // Inicializar con la fecha y hora actual
            FechaInicio = DateTime.Now;
            //FechaLimiteRespuesta10dias = DateTime.Now;
            //FechaLimiteRespuesta20dias = DateTime.Now;
            FechaRespuesta = DateTime.Now;
            //FechaLimitePrevencion10dias = DateTime.Now;
        }
    }

}
  