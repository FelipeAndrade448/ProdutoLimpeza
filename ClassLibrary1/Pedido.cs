using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoLimpeza
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public DateTime DataElaboracao { get; set; }

        [Required]
        public DateTime DataEfetivacao { get; set; }

        [Required]
        public int QuantidadeProduto { get; set; }

        public double ValorTotalProdutos { get; set; }

        public double ValorTotalPedido { get; set; }

        public StatusPedido statusDoPedido = StatusPedido.Aberto;

        public TipoDeVenda TipoDeVenda { get; set; }
        
        [Required]
        public Cliente Cliente { get; set; }

        public List<ItensPedido> ItensPedido = new List<ItensPedido>();

        public IEnumerable<object> Produtos { get; internal set; }


        #region Métodos Pedido

        public void EfetuaPedido(Pedido pedido)
        {
            pedido.CalculaValorTotalPedido(pedido);
            ItensPedido.RetiraProdutoEstoque(pedido);

        }

        public void CalculaValorTotalPedido(Pedido pedido)
        {
            if (pedido.StatusDoPedido == StatusPedido.Aberto)
            {
                foreach (var produto in pedido.Produtos)
                {
                    pedido.ValorTotalProdutos += (produto.Preco * pedido.QuantidadeProduto);
                    pedido.StatusDoPedido = StatusPedido.Faturar;
                }

                ValorTotalPedido += ValorTotalProdutos;
            }
        }       

        public void FaturarPedido(Pedido pedido)
        {
            if (pedido.statusDoPedido == StatusPedido.Aberto)
            {
                pedido.statusDoPedido = StatusPedido.Faturado;
            }
        }

        public void CancelaPedido(Pedido pedido)
        {
            if (pedido.StatusDoPedido != StatusPedido.Cancelado && pedido.StatusDoPedido != StatusPedido.Faturado)
            {
                pedido.StatusDoPedido = StatusPedido.Cancelado;
            }

            ItensPedido.EstornaProdutoEstoque(pedido);
        }

        #endregion

    }
}
