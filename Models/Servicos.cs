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
    }
}
