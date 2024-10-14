using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TstCompras.Models;
using System.Collections.Generic;

namespace TstCompras.Services
{
    public class MateriaisService
    {
        private readonly HttpClient _httpClient;

        public MateriaisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ItemContrato>> GetItensPorUASG(int uasgId)
        {
            try
            {
                // Requisição para obter contratos pela UASG
                var response = await _httpClient.GetAsync($"https://contratos.comprasnet.gov.br/api/contrato/ug/{uasgId}");
                
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var contratos = JsonSerializer.Deserialize<List<Contrato>>(data);

                    if (contratos == null || contratos.Count == 0)
                    {
                        return new List<ItemContrato>(); // Retorna uma lista vazia se não houver contratos
                    }

                    // Lista para armazenar os itens coletados de todos os contratos
                    var todosItens = new List<ItemContrato>();

                    // Iterar pelos contratos e buscar os itens de cada contrato
                    foreach (var contrato in contratos)
                    {
                        var itensResponse = await _httpClient.GetAsync(contrato.ItensUrl);
                        if (itensResponse.IsSuccessStatusCode)
                        {
                            var itensData = await itensResponse.Content.ReadAsStringAsync();
                            var itens = JsonSerializer.Deserialize<List<ItemContrato>>(itensData);
                            if (itens != null)
                            {
                                todosItens.AddRange(itens);
                            }
                        }
                    }

                    return todosItens;
                }
            }
            catch (HttpRequestException ex)
            {
                // Logar o erro (se você tiver um sistema de logging)
                // throw new Exception("Erro ao buscar itens: " + ex.Message);
            }

            return new List<ItemContrato>(); // Retorna uma lista vazia em caso de erro
        }
    }
}
