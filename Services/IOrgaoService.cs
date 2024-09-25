using System.Collections.Generic;
using System.Threading.Tasks;
using TstCompras.Models;

namespace TstCompras.Services
{
    public interface IOrgaoService
    {
        Task<Orgao> GetOrgao(int codigo);
        Task<List<Uasg>> GetUasgs(int codigoOrgao);
    }
}
