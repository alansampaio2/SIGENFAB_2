using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SIGENFAB.Web.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(3000);
            var anonimous = new ClaimsIdentity();
            var alanUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("Nome", "Alan"),
                new Claim("Sobrenome", "Mangueira Sampaio"),
                new Claim(ClaimTypes.Name, "Alan Mangueira Sampaio"),
                new Claim(ClaimTypes.Role, "Administrador")
            },
            authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(alanUser)));
        }
    }
}
