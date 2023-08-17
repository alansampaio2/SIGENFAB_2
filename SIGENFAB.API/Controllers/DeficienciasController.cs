using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGENFAB.API.Data;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeficienciasController : ControllerBase
    {
        private readonly Contexto _contexto;

        public DeficienciasController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _contexto.Deficiencias.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Deficiencia deficiencia)
        {
            _contexto.Add(deficiencia);
            await _contexto.SaveChangesAsync();
            return Ok(deficiencia);
        }
    }
}
