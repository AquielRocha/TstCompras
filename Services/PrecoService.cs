using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TstCompras.Models;
using System.Collections.Generic;

namespace TstCompras.Services
{
    public class PrecoService 
    {
        private readonly HttpClient _httpClient;

        public PrecoService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<List<Preco>> GetPrecos(int codigoItem)
        {
            // A URL agora tem os parâmetros padrão e o codigoItem como parâmetro de entrada
            var response = await _httpClient.GetAsync($"https://dadosabertos.compras.gov.br/modulo-pesquisa-preco/1_consultarMaterial?pagina=1&tamanhoPagina=10&codigoItemCatalogo={codigoItem}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var precoResponse = JsonConvert.DeserializeObject<PrecoResponse>(data);
                
                // Verifica se o resultado não está vazio
                if (precoResponse?.Resultado?.Count > 0)
                {
                    // Retorna todos os itens da lista de resultados
                    return precoResponse.Resultado; 
                }
            }

            return null; 
        }
    }
}
