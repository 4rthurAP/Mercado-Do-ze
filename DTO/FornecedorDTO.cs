using Mercado_Do_zé.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mercado_Do_zé.DTO
{
    public class FornecedorDTO
    {
        public int Id { get; set; }

        public string NomeFornecedor { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.)]
        public virtual List<Produto> Produtos { get; set; }
    }
}
