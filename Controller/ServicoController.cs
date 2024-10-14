using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TstCompras.Data;
using TstCompras.Models;

namespace TstCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/servico/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Servicos>>> GetServicos()
        {
            var servicos = await _context.Servicos.ToListAsync();
            return Ok(servicos);
        }

        // GET: api/servico/GetByCodigoItem/{codigo}
        [HttpGet("GetByCodigoItem/{codigo}")]
        public async Task<ActionResult<Servicos>> GetServicoByCodigoItem(int codigo)
        {
            var servico = await _context.Servicos.FirstOrDefaultAsync(s => s.codigo == codigo);

            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }

        // POST: api/servico/Add
        [HttpPost("Add")]
        public async Task<ActionResult<Servicos>> CreateServico([FromBody] Servicos servico)
        {
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServicoByCodigoItem), new { codigo = servico.codigo }, servico);
        }

        // PUT: api/servico/Edit/{codigo}
        [HttpPut("Edit/{codigo}")]
        public async Task<IActionResult> UpdateServico(int codigo, [FromBody] Servicos servico)
        {
            if (codigo != servico.codigo)
            {
                return BadRequest();
            }

            _context.Entry(servico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicoExists(codigo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/servico/Delete/{codigo}
        [HttpDelete("Delete/{codigo}")]
        public async Task<IActionResult> DeleteServico(int codigo)
        {
            var servico = await _context.Servicos.FindAsync(codigo);

            if (servico == null)
            {
                return NotFound();
            }

            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicoExists(int codigo)
        {
            return _context.Servicos.Any(e => e.codigo == codigo);
        }
    }
}
