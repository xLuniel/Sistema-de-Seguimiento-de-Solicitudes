using SolicitudesShared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public class ExpedienteService : IExpedienteService
    {
        private readonly HttpClient _http;

        public ExpedienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ExpedienteDTO>> Lista()
        {
            var response = await _http.GetFromJsonAsync<ResponseAPI<List<ExpedienteDTO>>>("/api/Expedientes/Lista");

            if (response!.Exito)
            {
                return response.Data!;
            }
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<ExpedienteDTO> Obtener(int id)
        {
            var response = await _http.GetFromJsonAsync<ResponseAPI<ExpedienteDTO>>($"api/Expedientes/Buscar/{id}​");

            if (response!.Exito)
            {
                return response.Data!;
            }
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(ExpedienteDTO Expediente)
        {
            var result = await _http.PutAsJsonAsync($"api/Expedientes/Editar/{Expediente.Id}", Expediente);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Exito)
            {
                return response.Data;
            }
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Crear(ExpedienteDTO NuevoExpediente)
        {
            var result = await _http.PostAsJsonAsync("api/Expedientes/Crear", NuevoExpediente);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Exito)
            {
                return response.Data!;
            }
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Expedientes/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Exito)
            {
                return response.Exito!;
            }
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<ResponseAPI<int>> Actualizar(ExpedienteDTO expediente)
        {
            var result = await _http.PutAsJsonAsync($"api/Expedientes/Actualizar/{expediente.Id}", expediente);

            // Verificar si la respuesta es exitosa
            if (!result.IsSuccessStatusCode)
            {
                var error = await result.Content.ReadAsStringAsync();
                throw new Exception($"Error en la API: {error}");
            }

            // Deserializar correctamente la respuesta
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Exito)
            {
                return response;
            }
            else
                throw new Exception(response.Mensaje);
        }
    }
}
