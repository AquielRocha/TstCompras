using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TstCompras.Models;
using TstCompras.Services;
using System.Collections.Generic;

namespace TstCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecoController : ControllerBase
    {
        private readonly PrecoService _precoService;

        public PrecoController(PrecoService precoService)
        {
            _precoService = precoService;
        }

        [HttpGet("getById/{codigoItem}")]
        public async Task<ActionResult<List<Preco>>> GetPrecos(int codigoItem)
        {
            var precos = await _precoService.GetPrecos(codigoItem);
            if (precos == null || precos.Count == 0)
            {
                return NotFound();
            }

            return Ok(precos); // Retorna a lista de preços
        }
    }
}
