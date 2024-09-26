using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TstCompras.Models;

namespace TstCompras.Services
{
    public class MateriaisService 
    {
        private readonly HttpClient _httpClient;

        public MateriaisService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<Materiais> GetMaterial(int codigoItem)
        {
            // A URL agora tem os parâmetros padrão e o codigoItem como parâmetro de entrada
            var response = await _httpClient.GetAsync($"https://dadosabertos.compras.gov.br/modulo-material/4_consultarItemMaterial?pagina=1&tamanhoPagina=10&codigoItem={codigoItem}&bps=false");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var materiaisResponse = JsonConvert.DeserializeObject<MateriaisResponse>(data);
                
                // Verifica se o resultado não está vazio
                if (materiaisResponse?.Resultado?.Count > 0)
                {
                    // Retorna o primeiro item da lista de resultados
                    return materiaisResponse.Resultado[0]; 
                }
            }

            return null; 
        }
    }
}
