﻿using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Seguimiento_de_Solicitudes.Models
{
    public class Expediente
    {
        // Identificador del expediente
        public int Id { get; set; }

        // Año de admisión
        public int AnoAdmision { get; set; }

        // Número de la solicitud
        public string? Folio { get; set; }

        // Mes de admisión
        public string MesAdmision { get; set; } = string.Empty;

        // Tipo de solicitud
        public string TipoSolicitud { get; set; } = string.Empty;

        // Tipo de derecho
        public string TipoDerecho { get; set; } = string.Empty;

        // Fecha de inicio del trámite
        public DateTime FechaInicioTramite { get; set; } = DateTime.Now;

        // Fecha límite de respuesta (10 días hábiles)
        public DateTime? FechaLimiteRespuesta10 { get; set; }

        // Indica si hubo una ampliación
        public string Ampliacion { get; set; } = string.Empty;

        // Número de la sesión del Comité que confirma la ampliación
        public int NumeroSesionComiteAmpliacion { get; set; }

        // Fecha de la sesión del Comité que confirma la ampliación
        public DateTime? FechaSesionComiteAmpliacion { get; set; }

        // Fecha límite de respuesta (20 días hábiles)
        public DateTime? FechaLimiteRespuesta20 { get; set; }

        // Estatus del expediente
        public string? Estatus { get; set; }

        // Fecha de respuesta de la solicitud
        public DateTime? FechaRespuesta { get; set; }

        // Promedio de días de respuesta
        public int PromedioDiasRespuesta { get; set; }

        // Indica si hubo prevención en la solicitud
        public bool Prevencion { get; set; } = false;

        // Información sobre la subsanación de la prevención y reinicio del trámite
        public string SubsanaPrevencion { get; set; } = string.Empty;

        // Fecha límite para subsanar la prevención
        public DateTime? FechaLimitePrevencion { get; set; }

        // Cómo fue recibida o registrada la solicitud en la PNT
        public string RecibidaRegistrada { get; set; } = string.Empty;

        // Medio de recepción en solicitud manual
        public string MedioRecepcionSolicitudManual { get; set; } = string.Empty;

        // Cómo desea recibir la respuesta la persona solicitante
        public string ComoDeseaRecibirRespuestaPersonaSolicitante { get; set; } = string.Empty;

        // Nombre del peticionario
        public string? Nombre { get; set; }


        // Correo electrónico del peticionario
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo electrónico válido.")]
        public string CorreoElectronico { get; set; } = string.Empty;

        // Contenido de la solicitud (puede ser muy largo)
        [DataType(DataType.MultilineText)]
        public string ContenidoSolicitud { get; set; } = string.Empty;


        // Área que posee la información
        public string AreaInformacion { get; set; } = string.Empty;

        // Materia de la solicitud
        public string Materia { get; set; } = string.Empty;

        // Ciudad del peticionario
        public string Ciudad { get; set; } = string.Empty;

        // Temática de la solicitud
        public string Tematica { get; set; } = string.Empty;

        // Temática específica de la solicitud
        public string TematicaEspecifica { get; set; } = string.Empty;

        // Sentido de la respuesta
        public string SentidoRespuesta { get; set; } = string.Empty;

        // Precisión del sentido de la respuesta
        public string PrecisionSentidoRespuesta { get; set; } = string.Empty;

        // Modalidad de entrega de la respuesta
        public string ModalidadEntrega { get; set; } = string.Empty;

        // Cobro asociado a la solicitud
        public string Cobro { get; set; } = string.Empty;

        // Indica si hay un recurso de revisión
        public string RecursoRevision { get; set; } = string.Empty;

        // Número de recurso de revisión
        public int NumeroRecursoRevision { get; set; }

        // Datos del recurso de revisión
        public string DatosRecursoRevision { get; set; } = string.Empty;

        // Nota adicional sobre el expediente
        public string Nota { get; set; } = string.Empty;


        // Constructor
        public Expediente()
        {
            // Inicializar con la fecha y hora actual
            FechaInicioTramite = DateTime.Now;
            //FechaLimiteRespuesta10 = DateTime.Now;
            //FechaLimiteRespuesta20 = DateTime.Now;
            FechaRespuesta = DateTime.Now;
            //FechaLimitePrevencion = DateTime.Now;
        }
    }
}