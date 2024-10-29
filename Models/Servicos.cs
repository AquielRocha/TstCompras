using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TstCompras.Models
{
    public class Servicos
    {
        [Key]
        public int codigo { get; set; }
        public string? descricao { get; set; }
        public int? codigo_grupo { get; set; }

        public int?  cpc { get; set; }

        public int? codigo_secao { get; set; }
        public int? codigo_divisao { get; set; }
        public int? codigo_classe { get; set; }

    }
}
