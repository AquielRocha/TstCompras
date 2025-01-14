using Newtonsoft.Json;

namespace TstCompras.Models
{
    public class Materiais
    {
        public int id { get; set; }
        public int codigo_item { get; set; }
        public string nome_item { get; set; } // equivale ao nome do pdm
        public string descricao_item { get; set; }
        public int codigo_grupo { get; set; }
        public string nome_grupo { get; set; }
        public string nome_classe { get; set; }
        public DateTime data_hora_atualizacao { get; set; }
    }
}
