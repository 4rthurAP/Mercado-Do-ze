using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mercado_Do_zé.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public float Preco { get; set; }

        public int Quantidade { get; set; }

        public int FornecedorID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string Fornecedor { get; set; }

    }
}
