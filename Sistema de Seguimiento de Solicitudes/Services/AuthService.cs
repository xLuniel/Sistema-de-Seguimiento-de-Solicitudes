using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using SolicitudesShared;

using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;


namespace Sistema_de_Seguimiento_de_Solicitudes.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> Login(string username, string password)
        {
            var token = await _http.GetFromJsonAsync<LoginResponse>("api/auth/login");
            if ( token is null)
            {
                throw new Exception();
            }
            //var response = await _http.PostAsJsonAsync("api/auth/login", new { NombreUsuario = username , password = password });

            //if (!response.IsSuccessStatusCode)
            //    return false;

            //var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            //await LocalStorage.SetAsync("auth_token", result.Token);

            //((CustomAuthenticationStateProvider)_authStateProvider).MarkUserAsAuthenticated(username);

            return true;
        }

        public async Task Logout()
        {
            //await LocalStorage.RemoveAsync("auth_token");
            //((CustomAuthenticationStateProvider)_authStateProvider).MarkUserAsLoggedOut();
        }

        public class LoginResponse
        {
            public string Token { get; set; }
           
        }
    }
}
