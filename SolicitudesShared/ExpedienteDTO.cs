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
        //Etapa Inicial
        public int Id { get; set; }
        public string? Folio { get; set; }
        public string? MesAdmision { get; set; }
        public string? TipoSolicitud { get; set; } 
        public string? TipoDerecho { get; set; } 
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? NombreSolicitante { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaLimiteRespuesta10dias { get; set; }
        public string? Ampliacion { get; set; }
        public DateTime FechaLimiteRespuesta20dias { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public int PromedioDiasRespuesta { get; set; }
        public bool Prevencion { get; set; } = false;
        public string? SubsanaPrevencion_ReinicoTramite { get; set; }
        public DateTime FechaLimitePrevencion10dias { get; set; }
        public string? ComoDeseaRecibirRespuestaPersonaSolicitante { get; set; }
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


        public ExpedienteDTO()
        {
            // Inicializar con la fecha y hora actual
            FechaInicio = DateTime.Now;
            FechaLimiteRespuesta10dias = DateTime.Now;
            FechaLimiteRespuesta20dias = DateTime.Now;
            FechaRespuesta = DateTime.Now;
            FechaLimitePrevencion10dias = DateTime.Now;
        }
    }

}
  