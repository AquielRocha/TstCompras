using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TstCompras.Models;
using TstCompras.Services;

namespace TstCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaisController : ControllerBase
    {
        private readonly MateriaisService _materiaisService; // Adicionado campo

        public MateriaisController(MateriaisService materiaisService)
        {
            _materiaisService = materiaisService; // Corrigido
        }

  [HttpGet("getById/{codigo_item}")] // Corrigido a rota
public async Task<ActionResult<Materiais>> GetMaterial(int codigo_item)
{
    var materiais = await _materiaisService.GetMaterial(codigo_item); // Corrigido
    if (materiais == null)
    {
        return NotFound();
    }

    return Ok(materiais); 
}

    }
}
