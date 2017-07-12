using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoLimpeza
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataFabricacao { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [Required]
        public double Preco { get; set; }

        [Required]
        public int QuantidadeProduto { get; set; }

        public TipoCategoria TipoDeCategoria { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
