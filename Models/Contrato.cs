using System.Text.Json.Serialization;

namespace TstCompras.Models
{
    public class Contrato
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("links")]
        public Links Links { get; set; }  // Nova classe para capturar os links

        public string ItensUrl => Links?.Itens; // Propriedade calculada para obter a URL dos itens
    }

    public class Links
    {
        [JsonPropertyName("itens")]
        public string Itens { get; set; }
    }
}
