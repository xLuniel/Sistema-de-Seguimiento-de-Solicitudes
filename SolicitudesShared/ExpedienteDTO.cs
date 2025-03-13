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
        public int Id { get; set; }

        public string? Folio { get; set; }

        public string? MesAdmision { get; set; }

        public string? TipoSolicitud { get; set; } // Se puede buscar por ID en otra tabla, mostrando los Tipos en un dropdown

        public string? TipoDerecho { get; set; } // Se puede buscar por ID en otra tabla, mostrando los Derechos en un dropdown

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? NombreSolicitante { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaLimiteRespuesta10dias { get; set; }

        public string? Ampliacion { get; set; }

        public DateTime? FechaLimiteRespuesta20dias { get; set; }

        public string? Estado { get; set; }

        public string? FechaRespuesta { get; set; }

        public string? Prevencion { get; set; }

        public string? SubsanaPrevencion_ReinicoTramite { get; set; }

        public string? FechaLimitePrevencion10dias { get; set; }

        public string? PreferenciaParaRecibirRespuesta { get; set; }

        public string? CorreoElectronicoSolicitante { get; set; }

        public string? ContenidoSolicitud { get; set; }

        public string? AreaPoseedoraInformacion { get; set; } // Se puede buscar por ID en otra tabla, mostrando las areas en un dropdown

        public string? Materia { get; set; } // Se puede buscar por ID en otra tabla, mostrando las Materias en un dropdown

        public string? CiudadSolicitante { get; set; }

        public string? Tematica { get; set; }

        public string? TematicaEspecifica { get; set; }

        public string? SentidoRespuesta { get; set; }

        public string? PrecisionSentidoRespuesta { get; set; }

        public string? ModalidadEntrega { get; set; } //Redundante con PreferenciaParaRecibirRespuesta

        public string? Cobro { get; set; }

        public string? RecursoRevision { get; set; }

        public string? DatosRecursoRevision { get; set; }

        public string? Nota { get; set; }

        // Agrega los demás campos de la tabla Expediente
    }
}
