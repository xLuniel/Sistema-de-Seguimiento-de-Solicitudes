using SolicitudesShared;


namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuariosDTO>> Lista_Usuarios();
        Task<int> Register(UsuariosDTO usuariosDTO);
        Task<bool> Eliminar(int id);
        Task<UsuariosDTO> Buscar(int id);



        Task<bool> CambiarContrasena(int usuarioId, string nuevaContrasena);

    }
}
