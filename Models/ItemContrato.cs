using System.Text.Json.Serialization;

namespace TstCompras.Models
{
    public class ItemContrato
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("contrato_id")]
        public int ContratoId { get; set; }

        [JsonPropertyName("tipo_id")]
        public string Tipo { get; set; }

        [JsonPropertyName("descricao_complementar")]
        public string DescricaoComplementar { get; set; }

        [JsonPropertyName("quantidade")]
        public string Quantidade { get; set; }

        [JsonPropertyName("valorunitario")]
        public string ValorUnitario { get; set; }

        [JsonPropertyName("valortotal")]
        public string ValorTotal { get; set; }
    }
}
