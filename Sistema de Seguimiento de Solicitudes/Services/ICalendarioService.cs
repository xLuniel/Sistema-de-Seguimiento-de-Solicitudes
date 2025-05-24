using Sistema_de_Seguimiento_de_Solicitudes.Models;
using SolicitudesShared;

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public interface ICalendarioService
    {
        Task<List<CalendarioDTO>> ObtenerDiasActivos();
        Task<bool> GuardarDiasActivos(List<CalendarioDTO> diasActivos);

        Task<List<DiaInhabilManualDTO>> ObtenerDiasInhabiles();
        Task GuardarDiaInhabil(DiaInhabilManualDTO diaInhabil);
        Task EliminarDiaInhabil(DateTime fecha);
    }

}
