using SolicitudesShared;

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public interface IExpedienteService
    {
        Task<List<ExpedienteDTO>> Lista();

        Task<ExpedienteDTO> Obtener(int id);

        Task<int> Crear(ExpedienteDTO Expediente);

        Task<int> Actualizar(ExpedienteDTO Expediente);

        Task<bool> Eliminar(int id);
    }
}
