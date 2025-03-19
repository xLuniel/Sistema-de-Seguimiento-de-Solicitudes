using Sistema_de_Seguimiento_de_Solicitudes.Models; // Asegúrate de que este espacio de nombres es correcto
using SolicitudesShared;
using System.Net.Http.Json; // Asegúrate de que este espacio de nombres está incluido

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public class CalendarioService : ICalendarioService
    {
        private readonly HttpClient _http;

        public CalendarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CalendarioDTO>> ObtenerDiasActivos()
        {
            var response = await _http.GetFromJsonAsync<List<CalendarioDTO>>("api/calendario");
            return response ?? new List<CalendarioDTO>();
        }

        public async Task<bool> GuardarDiasActivos(List<CalendarioDTO> diasActivos)
        {
            var response = await _http.PostAsJsonAsync("api/calendario", diasActivos);
            return response.IsSuccessStatusCode;
        }
    }
}
