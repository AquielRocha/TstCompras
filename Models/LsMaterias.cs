using Newtonsoft.Json;

namespace TstCompras.Models
{
    public class LsMateriais
    {
        public int id { get; set; }
        public string codigo_do_grupo { get; set; } // Atualizado para refletir o nome correto
        public string nome_do_grupo { get; set; }
        public string codigo_da_classe { get; set; }
        public string nome_da_classe { get; set; }
        public string codigo_do_pdm { get; set; }
        public string nome_do_pdm { get; set; }
        public string codigo_do_item { get; set; }
        public string descricao_do_item { get; set; }
        public string codigo_ncm { get; set; }
    }
}
