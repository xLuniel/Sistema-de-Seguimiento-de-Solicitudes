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
            var response = await _http.GetFromJsonAsync<List<CalendarioDTO>>("/api/Calendario/Obtener_dias");
            return response ?? new List<CalendarioDTO>();
        }

        public async Task<bool> GuardarDiasActivos(List<CalendarioDTO> diasActivos)
        {
            var response = await _http.PostAsJsonAsync("/api/Calendario/Guardar_dia", diasActivos);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<DiaInhabilManualDTO>> ObtenerDiasInhabiles()
        {
            var response = await _http.GetFromJsonAsync<List<DiaInhabilManualDTO>>("/api/Calendario/Get_DiasInhabiles");
            return response ?? new List<DiaInhabilManualDTO>();
        }

        public async Task GuardarDiaInhabil(DiaInhabilManualDTO diaInhabil)
        {
            var result = await _http.PostAsJsonAsync("/api/Calendario/Guardar_DiasInhabiles", diaInhabil);
            //var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (!result.IsSuccessStatusCode)
            {
                var mensaje = await result.Content.ReadAsStringAsync();
                throw new Exception($"Error al guardar día inhábil: {mensaje}");
            }

        }

        public async Task EliminarDiaInhabil(DateTime fecha)
        {
            var fechaUrl = fecha.ToString("yyyy-MM-dd");
            var response = await _http.DeleteAsync($"api/Calendario/Eliminar_DiaInhabil/{fechaUrl}");
            //var response = await result.Content.ReadFromJsonAsync<ResponseAPI<DateTime>>();

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar día inhábil: {error}");
            }

        }
    }
}
