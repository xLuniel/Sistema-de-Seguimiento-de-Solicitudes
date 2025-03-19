using SolicitudesShared;

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public interface IExpedienteService
    {
        Task<ResponseAPI<ExpedienteDTO>> Actualizar(ExpedienteDTO expediente);
        Task<List<ExpedienteDTO>> Lista();
        Task<ExpedienteDTO> Obtener(int id);
        Task<int> Editar(ExpedienteDTO Expediente);
        Task<int> Crear(ExpedienteDTO NuevoExpediente);
        Task<bool> Eliminar(int id);
    }
}
