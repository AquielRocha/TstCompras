using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TstCompras.Data;

namespace TstCompras.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TstController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TstController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Teste de conexão ao banco de dados
        [HttpGet("testeConexao")]
        public async Task<ActionResult<string>> TestConnection()
        {
            try
            {
                await _context.Database.CanConnectAsync();
                return Ok("Conexão bem-sucedida!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}
