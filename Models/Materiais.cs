using Newtonsoft.Json;
using System.Collections.Generic;

namespace TstCompras.Models
{
    public class Materiais
    {
        [JsonProperty("codigoGrupo")]
        public int CodigoGrupo { get; set; }

        [JsonProperty("nomeGrupo")]
        public string NomeGrupo { get; set; }

        [JsonProperty("codigoClasse")]
        public int CodigoClasse { get; set; }

        [JsonProperty("nomeClasse")]
        public string NomeClasse { get; set; }

        [JsonProperty("codigoPdm")]
        public int CodigoPdm { get; set; }

        [JsonProperty("nomePdm")]
        public string NomePdm { get; set; }

        [JsonProperty("codigoItem")]
        public int CodigoItem { get; set; }

        [JsonProperty("descricaoItem")]
        public string DescricaoItem { get; set; }

        [JsonProperty("statusItem")]
        public bool StatusItem { get; set; }

        [JsonProperty("itemSustentavel")]
        public bool ItemSustentavel { get; set; }

        [JsonProperty("dataHoraAtualizacao")]
        public string DataHoraAtualizacao { get; set; }
    }

    public class MateriaisResponse
    {
        [JsonProperty("resultado")]
        public List<Materiais> Resultado { get; set; }

        [JsonProperty("totalRegistros")]
        public int TotalRegistros { get; set; }

        [JsonProperty("totalPaginas")]
        public int TotalPaginas { get; set; }

        [JsonProperty("paginasRestantes")]
        public int PaginasRestantes { get; set; }
    }
}
