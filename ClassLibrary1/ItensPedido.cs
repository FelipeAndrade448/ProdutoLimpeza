using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoLimpeza
{
    public class ItensPedido
    {
        [Required]
        public List<Produto> Produto = new List<Produto>();



        #region Métodos

        public void RetiraProdutoEstoque(Pedido pedido)
        {
            foreach (var produtos in pedido.ItensPedido)
            {
                foreach (var produto in produtos.Produto)
                {
                    produto.QuantidadeProduto -= pedido.QuantidadeProduto;
                }               
            }
        }

        public void EstornaProdutoEstoque(Pedido pedido)
        {
            if (pedido.statusDoPedido == StatusPedido.Faturado)
            {
                foreach (var produtos in pedido.ItensPedido)
                {
                    foreach (var produto in produtos.Produto)
                    {
                        produto.QuantidadeProduto += pedido.QuantidadeProduto;
                    }                   
                }
            }
        }

        #endregion

    }
}
