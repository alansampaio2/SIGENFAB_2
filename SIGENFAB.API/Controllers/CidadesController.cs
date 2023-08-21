using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGENFAB.API.Data;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly Contexto _contexto;

        public CidadesController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _contexto.Cidades
            .Include(x => x.Bairros)
            .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var cidade = await _contexto.Cidades
            .Include(x => x.Bairros!).ThenInclude(x => x.Logradouros)
            .FirstOrDefaultAsync(x => x.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            return Ok(cidade);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Cidade cidade)
        {
            try
            {
                _contexto.Add(cidade);
                await _contexto.SaveChangesAsync();
                return Ok(cidade);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Já existe uma Cidade com esse mesmo nome.");
                }
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Cidade cidade)
        {
            try
            {
                _contexto.Update(cidade);
                await _contexto.SaveChangesAsync();
                return Ok(cidade);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Já existe uma Cidade com esse mesmo nome.");
                }
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var cidade = await _contexto.Cidades.FirstOrDefaultAsync(x => x.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            _contexto.Remove(cidade);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
