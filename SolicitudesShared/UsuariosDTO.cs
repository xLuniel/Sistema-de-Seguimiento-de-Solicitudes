using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesShared
{
    public class UsuariosDTO
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "El Usuario es requerido")]
        [StringLength(100)]
        public required string NombreUsuario { get; set; }

        [Required (ErrorMessage = "La contraseña es requerida")]
        public required string password { get; set; }

        public required string Rol { get; set; }
    }
}
