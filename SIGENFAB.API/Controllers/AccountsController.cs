using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SIGENFAB.API.Managers;
using SIGENFAB.Shared.DTOs;
using SIGENFAB.Shared.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIGENFAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUsuarioManager _userManger;
        private readonly IConfiguration _configuration;

        public AccountsController(IUsuarioManager userManger, IConfiguration configuration)
        {
            _userManger = userManger;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO model)
        {
            var result = await _userManger.LoginAsync(model);
            if (result.Succeeded)
            {
                var user = await _userManger.SelecionaUsuarioAsync(model.CPF);
                return Ok(BuildToken(user));
            }
            return BadRequest("Email o contraseña incorrectos.");
        }

        private TokenDTO BuildToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Name, usuario.Email!),
                //new Claim(ClaimTypes.Role, usuario.UserType.ToString()),
                new Claim("CPF", usuario.CPF),
                new Claim("Nome", usuario.Nome),
                new Claim("Sobrenome", usuario.Sobrenome),
                //new Claim("Address", usuario.Address),
                //new Claim("Photo", usuario.Photo ?? string.Empty),
                //new Claim("CityId", usuario.CityId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);
            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
