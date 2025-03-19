using Sistema_de_Seguimiento_de_Solicitudes.Models;

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public interface ICalendarioService
    {
        Task<List<CalendarioDTO>> ObtenerDiasActivos();
        Task<bool> GuardarDiasActivos(List<CalendarioDTO> diasActivos);
    }

}
