using System.ComponentModel.DataAnnotations;

namespace SolicitudesAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string NombreUsuario { get; set; }

        [Required]
        public required string password { get; set; }

        public required string Rol { get; set; }
    }
}
