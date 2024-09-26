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
        private readonly MateriaisService _materiaisService;

        public MateriaisController(MateriaisService materiaisService)
        {
            _materiaisService = materiaisService;
        }

        [HttpGet("getById/{codigoItem}")] // Ajustada a rota
        public async Task<ActionResult<Materiais>> GetMaterial(int codigoItem)
        {
            var materiais = await _materiaisService.GetMaterial(codigoItem);
            if (materiais == null)
            {
                return NotFound();
            }

            return Ok(materiais); 
        }
    }
}
