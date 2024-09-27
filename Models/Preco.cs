using Newtonsoft.Json;

namespace TstCompras.Models
{
    public class Preco
    {
        [JsonProperty("descricaoItem")]
        public string DescricaoItem { get; set; }
      
        [JsonProperty("precoUnitario")]
        public decimal PrecoUnitario { get; set; }
    }

    public class PrecoResponse
    {
        [JsonProperty("resultado")]
        public List<Preco> Resultado { get; set; }

        [JsonProperty("totalRegistros")]
        public int TotalRegistros { get; set; }

        [JsonProperty("totalPaginas")]
        public int TotalPaginas { get; set; }

        [JsonProperty("paginasRestantes")]
        public int PaginasRestantes { get; set; }
    }
}
