using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoLimpeza
{
    public class Produto
    {
        #region Propriedades

        public int Id { get; set; }

        [Required]
        public string CodigoProduto { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataFabricacao { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [Required]
        public double PrecoProduto { get; set; }

        [Required]
        public int ProdutoEmEstoque { get; set; }

        public Categoria Categoria { get; set; }

        public Fornecedor Fornecedor { get; set; }

        #endregion

        #region Métodos
        public bool ValidaEstoque(int quantidadeProduto)
        {
            if (quantidadeProduto <= 0 )
            {
                throw new System.ArgumentException("Produto com quantidade Zero ou Negativo");
            }
            else if (quantidadeProduto > ProdutoEmEstoque)
            {
                throw new System.ArgumentException("Quantidade de produto maior que a disponível em estoque");
            }                
            else
                return true;
        }

        public bool ValidaPrecoProduto()
        {
            if (PrecoProduto <= 0)
            {
                return false;
                throw new System.ArgumentException("Preço Zero ou negativo");
            }                
            else
                return true;
        }

        #endregion
    }
}
