using Newtonsoft.Json;

namespace TstCompras.Models
{
    public class Materiais
    {
        [JsonProperty("codigo")]
        public int Codigo { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        // Os outros campos não são necessários se você não os vai usar
    }

    public class MateriaisResponse
    {
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }

    public class Embedded
    {
        [JsonProperty("materiais")]
        public List<Materiais> Materiais { get; set; }
    }
}
