using Microsoft.AspNetCore.Identity;
using SIGENFAB.Shared.DTOs;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.API.Managers
{
    public interface IUsuarioManager
    {
        Task<Usuario> SelecionaUsuarioAsync(string cpf);
        Task<IdentityResult> AdicionarUsuarioAsync(Usuario usuario, string senha);
        Task VerificarFuncaoAsync(string nomeDaFuncao);
        Task AdicionarUsuarioParaFuncao(Usuario usuario, string nomeDaFuccao);
        Task<bool> UsuarioEstaNaFuncao(Usuario usuario, string nomeDaFuncao);
        Task<SignInResult> LoginAsync(LoginDTO model);
        Task LogoutAsync();
    }
}
