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
    public class MateriaisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MateriaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/materiais
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Materiais>>> GetMateriais()
        {
            var materiais = await _context.Materiais.ToListAsync();
            return Ok(materiais);
        }

// GET: api/materiais/GetByCodigoItem/{codigo_item}
        [HttpGet("GetByCodigoItem/{codigo_item}")]
        public async Task<ActionResult<Materiais>> GetMaterialByCodigoItem(int codigo_item)
        {
            var material = await _context.Materiais.FirstOrDefaultAsync(m => m.codigo_item == codigo_item);

            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }


        // // POST: api/materiais
        // [HttpPost("Add")]
        // public async Task<ActionResult<Materiais>> CreateMaterial([FromBody] Materiais material)
        // {
        //     _context.Materiais.Add(material);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetMaterial), new { id = material.id }, material);
        // }

        // PUT: api/materiais/{id}
        [HttpPut("Edit")]
        public async Task<IActionResult> UpdateMaterial(int id, [FromBody] Materiais material)
        {
            if (id != material.id)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // DELETE: api/materiais/{id}
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Materiais.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            _context.Materiais.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(int id)
        {
            return _context.Materiais.Any(e => e.id == id);
        }
    }
}
