using SolicitudesShared;

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public interface IExpedienteService
    {
        // ✅ Obtener todos los expedientes
        Task<List<ExpedienteDTO>> Lista();

        // ✅ Buscar un expediente por ID
        Task<ExpedienteDTO> Buscar(int id);

        // ✅ Crear un expediente
        Task<int> Crear(ExpedienteDTO expediente);

        // ✅ Eliminar un expediente
        Task<bool> Eliminar(int id);

        // ✅ Actualizar un expediente
        Task<bool> Actualizar(ExpedienteDTO expediente);

        // ✅ Buscar por folio o contenido de solicitud
        Task<List<ExpedienteDTO>> BuscarPorTexto(string filtro);
    }
}
