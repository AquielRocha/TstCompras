using Newtonsoft.Json;

namespace TstCompras.Models
{
    public class Orgao
    {
        [JsonProperty("codigo")]
        public int Codigo { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("codigo_tipo_adm")]
        public int CodigoTipoAdm { get; set; }

        [JsonProperty("codigo_tipo_esfera")]
        public string CodigoTipoEsfera { get; set; }

        [JsonProperty("codigo_tipo_poder")]
        public int CodigoTipoPoder { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }

    public class Uasg
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("id_orgao_superior")]
        public int IdOrgaoSuperior { get; set; }



        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("total_fornecedores_cadastrados")]
        public int TotalFornecedoresCadastrados { get; set; }

        [JsonProperty("total_fornecedores_recadastrados")]
        public int TotalFornecedoresRecadastrados { get; set; }

        [JsonProperty("unidade_cadastradora")]
        public bool UnidadeCadastradora { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
    
    public class OrgaoWithUasgs
    {
        public Orgao Orgao { get; set; }
        public List<Uasg> Uasgs { get; set; }
    }
}
