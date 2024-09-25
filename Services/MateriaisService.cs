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

public async Task<Materiais> GetMaterial(int codigo_item)
{
    var response = await _httpClient.GetAsync($"https://compras.dados.gov.br/materiais/v1/materiais.json?codigo_item={codigo_item}");
    if (response.IsSuccessStatusCode)
    {
        var data = await response.Content.ReadAsStringAsync();
        var materiaisResponse = JsonConvert.DeserializeObject<MateriaisResponse>(data);
        
        // Verifica se a lista de materiais não está vazia
        if (materiaisResponse?.Embedded?.Materiais?.Count > 0)
        {
            // Retorna o primeiro item da lista de materiais
            return materiaisResponse.Embedded.Materiais[0]; 
        }
    }

    return null; 
}

    }
}
