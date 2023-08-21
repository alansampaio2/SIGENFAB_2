using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGENFAB.API.Data;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BairrosController : ControllerBase
    {
        private readonly Contexto _contexto;

        public BairrosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _contexto.Bairros
            .Include(x => x.Logradouros)
            .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var cidade = await _contexto.Bairros
            .Include(x => x.Logradouros!)
            .FirstOrDefaultAsync(x => x.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            return Ok(cidade);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Bairro bairro)
        {
            try
            {
                _contexto.Add(bairro);
                await _contexto.SaveChangesAsync();
                return Ok(bairro);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Já existe um Bairro com esse mesmo nome.");
                }
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Bairro bairro)
        {
            try
            {
                _contexto.Update(bairro);
                await _contexto.SaveChangesAsync();
                return Ok(bairro);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Já existe um Bairro com esse mesmo nome.");
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
            var bairro = await _contexto.Bairros.FirstOrDefaultAsync(x => x.Id == id);
            if (bairro == null)
            {
                return NotFound();
            }
            _contexto.Remove(bairro);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
