using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mercado_Do_zé.Models
{
    public class Produto 
    {
        [Key()]
        public int Id { get; set; }
        [Range(10,300, ErrorMessage = "Deve ter de 10 a 300 caracteres")]
        public string Descricao { get; set; }
        [MinLength(1)]
        public float Preco { get; set; }
        [MinLength(1)]
        public int Quantidade { get; set; }

        [Required]
        public int FornecedorID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual Fornecedor Fornecedor { get; set; }

    }

}
