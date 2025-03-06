using SolicitudesShared;
using System.Net.Http.Json;

namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public class ExpedienteService : ITestExpedienteService
    {
        private readonly HttpClient _http;

        public ExpedienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TestExpedienteDTO>> Lista()
        {
            var response = await _http.GetFromJsonAsync<ResponseAPI<List<TestExpedienteDTO>>>("/api/TestExpedientes/Lista​");

            if (response!.Exito)
            {
                return response.Data!;
            }
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<TestExpedienteDTO> Obtener(int id)
        {
            var response = await _http.GetFromJsonAsync<ResponseAPI<TestExpedienteDTO>>($"/api/TestExpedientes/single/{id}​");

            if (response!.Exito)
            {
                return response.Data!;
            }
            else
                throw new Exception(response.Mensaje);
        }
        public async Task<int> Actualizar(TestExpedienteDTO testExpediente)
        {
            var result = await _http.PutAsJsonAsync($"/api/TestExpedientes/Editar/{testExpediente.Id}", testExpediente);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Exito)
            {
                return response.Data!;
            }
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Crear(TestExpedienteDTO testExpediente)
        {
            var result = await _http.PostAsJsonAsync("/api/TestExpedientes/add​", testExpediente);
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
            var result = await _http.DeleteAsync($"/api/TestExpedientes/Editar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Exito)
            {
                return response.Exito;
            }
            else
                throw new Exception(response.Mensaje);
        }

        
    }
}
