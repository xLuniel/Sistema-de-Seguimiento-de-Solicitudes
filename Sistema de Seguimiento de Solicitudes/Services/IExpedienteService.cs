using SolicitudesShared;
using Sistema_de_Seguimiento_de_Solicitudes.Services;

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public interface IExpedienteService
    {
        Task<List<ExpedienteDTO>> Lista();

        Task<ExpedienteDTO> Obtener(int id);

        Task<ResponseAPI<ExpedienteDTO>> Actualizar(ExpedienteDTO expediente);
        Task<int> Crear(ExpedienteDTO Expediente);
        Task<int> Editar(ExpedienteDTO Expediente);
        Task<bool> Eliminar(int id);
    }
}
