using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TstCompras.Models;

namespace TstCompras.Services
{
    public class OrgaoService : IOrgaoService
    {
        private readonly HttpClient _httpClient;

        public OrgaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Orgao> GetOrgao(int codigo)
        {
            var response = await _httpClient.GetAsync($"https://compras.dados.gov.br/licitacoes/doc/orgao/{codigo}.json");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Orgao>(data);
            }

            return null; 
        }

        public async Task<List<Uasg>> GetUasgs(int codigoOrgao)
        {
            var response = await _httpClient.GetAsync($"https://compras.dados.gov.br/licitacoes/v1/uasgs.json?id_orgao={codigoOrgao}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UasgResponse>(data);
                return result.Embedded.Uasgs; 
            }

            return null; 
        }
    }

    public class UasgResponse
    {
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }

    public class Embedded
    {
        [JsonProperty("uasgs")]
        public List<Uasg> Uasgs { get; set; }
    }
}
