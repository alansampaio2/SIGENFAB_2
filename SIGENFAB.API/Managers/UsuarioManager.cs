using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIGENFAB.API.Data;
using SIGENFAB.Shared.DTOs;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.API.Managers
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly Contexto _contexto;
        private readonly UserManager<Usuario> _manager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioManager(Contexto contexto, UserManager<Usuario> manager, RoleManager<IdentityRole> roleManager, SignInManager<Usuario> signInManager)
        {
            _contexto = contexto;
            _manager = manager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public Task<IdentityResult> AdicionarUsuarioAsync(Usuario usuario, string senha)
        {
            return _manager.CreateAsync(usuario, senha);
        }

        public async Task AdicionarUsuarioParaFuncao(Usuario usuario, string nomeDaFuccao)
        {
            await _manager.AddToRoleAsync(usuario, nomeDaFuccao);
        }

        public async Task<bool> UsuarioEstaNaFuncao(Usuario usuario, string nomeDaFuncao)
        {
            return await _manager.IsInRoleAsync(usuario, nomeDaFuncao);
        }

        public async Task<Usuario> SelecionaUsuarioAsync(string cpf)
        {
            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.CPF == cpf);
            if(usuario != null)
            {
                return usuario;
            }

            return null!;
        }

        public async Task VerificarFuncaoAsync(string nomeDaFuncao)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(nomeDaFuncao);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = nomeDaFuncao
                });
            }
        }

        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.CPF, model.Password, false, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
