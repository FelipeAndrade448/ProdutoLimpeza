using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoLimpeza
{
    public class ItemPedido
    {
        #region Propriedades ItemPedido

        [Required]
        public Produto Produto { get; set; }

        [Required]
        public int QuantidadeProduto { get; set; }

        public double TotalItemPedido { get; set; }

        #endregion

        #region Métodos

        public void CalculaTotalItemPedido()
        {
            var validaQuantidadeProduto = ValidaQuantidadeProduto();

            if (validaQuantidadeProduto)
            {
                TotalItemPedido += (Produto.PrecoProduto * QuantidadeProduto); 
            }

        }  

        public bool ValidaQuantidadeProduto( )
        {
            if (QuantidadeProduto <= 0)
            {
                return false;
                throw new System.ArgumentException("Quantidade do Produto é zero ou negativo");
            }
            else
                return true;
        }

        #endregion

    }
}
