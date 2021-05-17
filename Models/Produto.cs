using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado_Do_zé.Models
{
    public class Produto 
    {
        [Key()]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public float Preco { get; set; }

        public int Quantidade { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

    }

}
