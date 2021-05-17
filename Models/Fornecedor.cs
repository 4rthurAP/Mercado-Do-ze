using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado_Do_zé.Models
{
    public class Fornecedor
    {
        [Key()]
        public int Id { get; set; }

        public string NomeFornecedor { get; set; }

        public virtual Produto Produtos {get; set;}
    }
}
