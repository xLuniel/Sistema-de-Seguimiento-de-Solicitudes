using SolicitudesShared;

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public interface ITestExpedienteService
    {
        Task<List<TestExpedienteDTO>> Lista();

        Task<TestExpedienteDTO> Obtener(int id);

        Task<int> Crear(TestExpedienteDTO testExpediente);

        Task<int> Actualizar(TestExpedienteDTO testExpediente);

        Task<bool> Eliminar(int id);
    }
}
