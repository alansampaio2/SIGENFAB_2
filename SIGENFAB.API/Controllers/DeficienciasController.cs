using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGENFAB.API.Data;
using SIGENFAB.Shared.Entities;
using System;

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

            try
            {
                await _contexto.SaveChangesAsync();
                return Ok(deficiencia);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Já existe uma deficiencia com esta mesmo nome.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var country = await _contexto.Deficiencias.FirstOrDefaultAsync(x => x.Id == id);
            if (country is null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Deficiencia deficiencia)
        {
            _contexto.Update(deficiencia);
            try
            {
                await _contexto.SaveChangesAsync();
                return Ok(deficiencia);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Já existe uma deficiencia com esta mesmo nome.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _contexto.Deficiencias
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
