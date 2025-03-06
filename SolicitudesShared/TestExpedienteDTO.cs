using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SolicitudesShared
{
    public class TestExpedienteDTO
    {
        public int Id { get; set; }

        public string? Folio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? NombreSolicitante { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? FechaInicio { get; set; }

        public string? Estado { get; set; }

        public string? ContenidoSolicitud { get; set; }
    }
}
