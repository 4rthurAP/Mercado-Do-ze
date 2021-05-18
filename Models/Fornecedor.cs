using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Mercado_Do_zé.Models
{
    public class Fornecedor
    {
        [Key()]
        public int Id { get; set; }
        public string NomeFornecedor { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual List<Produto> Produtos { get; set; }
    }
}
