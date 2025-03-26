using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using SolicitudesShared;

using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;


namespace Sistema_de_Seguimiento_de_Solicitudes.Services.LoginServices
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly CustomAuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, CustomAuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<LoginResponse> Login(LoginDTO model)
        {
            //var token = await _http.GetFromJsonAsync<LoginResponse>("api/auth/login");
            //if ( token is null)
            //{
            //    throw new Exception();
            //}
            var response = await _http.PostAsJsonAsync("https://localhost:7123/api/Auth/login", model );

            //if (!response.IsSuccessStatusCode)
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Login failed: {errorContent}");
            }


            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            if (result is null)
            {
                throw new Exception("Invalid response from server");
            }

            if (result.Flag)
            {
                await _authStateProvider.SetToken(result.Token);
            }
            //if (result != null)
            //{
            //    await _authStateProvider.SetToken(result.Token);
            //    //return true;
            //}
            //await LocalStorage.SetAsync("auth_token", result.Token);

            //((CustomAuthenticationStateProvider)_authStateProvider).MarkUserAsAuthenticated(username);
            return result!;

        }

        public async Task Logout()
        {
            await _authStateProvider.SetToken(null);
           // await LocalStorage.RemoveAsync("auth_token");
            //((CustomAuthenticationStateProvider)_authStateProvider).MarkUserAsLoggedOut();
        }

        //public class LoginResponse
        //{
        //    public string Token { get; set; }
        //    public bool Flag = false;
           
        //}
    }
}
