using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TstCompras.Models;
using TstCompras.Services;

namespace TstCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgaoController : ControllerBase
    {
        private readonly IOrgaoService _orgaoService;

        public OrgaoController(IOrgaoService orgaoService)
        {
            _orgaoService = orgaoService;
        }

        [HttpGet("getById{codigo}")]
        public async Task<ActionResult<OrgaoWithUasgs>> GetOrgao(int codigo)
        {
            var orgao = await _orgaoService.GetOrgao(codigo);
            if (orgao == null)
            {
                return NotFound();
            }

            var uasgs = await _orgaoService.GetUasgs(codigo);
            var result = new OrgaoWithUasgs
            {
                Orgao = orgao,
                Uasgs = uasgs
            };

            return Ok(result);
        }
    }
}
