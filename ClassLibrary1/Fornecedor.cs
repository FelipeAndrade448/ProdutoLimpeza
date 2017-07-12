using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoLimpeza
{
    public class Fornecedor : Pessoa
    {
        public int Id { get; set; }

        [Required]
        public string NomeFantasia { get; set; }
    }
}
