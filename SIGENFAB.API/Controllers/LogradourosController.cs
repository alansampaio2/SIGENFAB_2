using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGENFAB.API.Data;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogradourosController : ControllerBase
    {
        private readonly Contexto _contexto;

        public LogradourosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _contexto.Logradouros
            .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var logradouro = await _contexto.Logradouros
            .FirstOrDefaultAsync(x => x.Id == id);
            if (logradouro == null)
            {
                return NotFound();
            }
            return Ok(logradouro);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Logradouro logradouro)
        {
            _contexto.Add(logradouro);
            try
            {                
                await _contexto.SaveChangesAsync();
                return Ok(logradouro);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Já existe um Logradouro com esse mesmo nome.");
                }
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Logradouro logradouro)
        {
            _contexto.Update(logradouro);
            try
            {                
                await _contexto.SaveChangesAsync();
                return Ok(logradouro);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Já existe um Logradouro com esse mesmo nome.");
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
            var bairro = await _contexto.Logradouros.FirstOrDefaultAsync(x => x.Id == id);
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
