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
    public class LsMateriaisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LsMateriaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/lsmateriais
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<LsMateriais>>> GetAll()
        {
            return await _context.ListaCatmat.ToListAsync();
        }

        // GET: api/lsmateriais/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LsMateriais>> GetById(int id)
        {
            var lsMaterial = await _context.ListaCatmat.FindAsync(id);

            if (lsMaterial == null)
            {
                return NotFound();
            }

            return Ok(lsMaterial);
        }

        // POST: api/lsmateriais
        [HttpPost("Add")]
        public async Task<ActionResult<LsMateriais>> Create([FromBody] LsMateriais lsMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ListaCatmat.Add(lsMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = lsMaterial.id }, lsMaterial);
        }

        // PUT: api/lsmateriais/{id}
        [HttpPut("Edit{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LsMateriais lsMaterial)
        {
            if (id != lsMaterial.id)
            {
                return BadRequest();
            }

            _context.Entry(lsMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LsMaterialExists(id))
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

        // DELETE: api/lsmateriais/{id}
        [HttpDelete("Del{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lsMaterial = await _context.ListaCatmat.FindAsync(id);

            if (lsMaterial == null)
            {
                return NotFound();
            }

            _context.ListaCatmat.Remove(lsMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método auxiliar para verificar se um registro existe
        private bool LsMaterialExists(int id)
        {
            return _context.ListaCatmat.Any(e => e.id == id);
        }
    }
}
