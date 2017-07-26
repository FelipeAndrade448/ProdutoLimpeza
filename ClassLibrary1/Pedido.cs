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
        #region Propriedades Pedido

        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public DateTime DataElaboracao { get; set; }

        public double ValorTotalProdutos { get; set; }

        public double ValorTotalPedido { get; set; }

        public StatusPedido statusDoPedido = StatusPedido.Aberto;

        public TipoDeVenda TipoDeVenda { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

        public List<ItemPedido> ItensPedido = new List<ItemPedido>();

        [Required]
        public int TotalParcelas = 1;

        public double ValorParcelas { get; set; }

        public int TotalProdutosPedido { get; set; }

        #endregion 


        #region Métodos Pedido

        public void AdicionaItemPedido()
        {
            foreach(var item in ItensPedido)
            {
                item.CalculaTotalItemPedido();
            }

            this.CalculaValorTotalPedido();
            this.RetiraProdutoEstoque();
        }

        private void RemoveItemPedido()
        {
            if (statusDoPedido != StatusPedido.Aberto && statusDoPedido != StatusPedido.Faturado)
            {
                foreach (var produto in ItensPedido)
                {
                    ItensPedido.Remove(produto);
                }
            }
            else
                throw new System.ArgumentException("Não se pode remover Itens que não estão no status de Faturar ou Faturado");
        }

        private void CalculaValorTotalPedido()
        {
            ValidaParcela();

            if (statusDoPedido == StatusPedido.Aberto && TipoDeVenda != TipoDeVenda.Invalido)
            {
                foreach (var itemPedido in ItensPedido)
                {
                    var preco = itemPedido.Produto.ValidaPrecoProduto();

                    if (preco)
                    {
                        ValorTotalPedido += itemPedido.TotalItemPedido;
                    }
                    else
                        throw new System.ArgumentException("Produto com preço zero ou negativo");

                   TotalProdutosPedido += itemPedido.QuantidadeProduto;
                }

                statusDoPedido = StatusPedido.Faturar;
            }
            else
                throw new System.ArgumentException("Pedido não se está com o status a Faturar");

        }

        private void RetiraProdutoEstoque()
        {
            foreach (var produto in ItensPedido)
            {
                var validaEstoque = produto.Produto.ValidaEstoque(produto.QuantidadeProduto);

                if (validaEstoque)
                {
                    produto.Produto.ProdutoEmEstoque -= produto.QuantidadeProduto;
                }
            }
        }

        public void EstornaProdutoEstoque()
        {
            if (statusDoPedido != StatusPedido.Aberto)
            {
                foreach (var produto in ItensPedido)
                {
                    produto.Produto.ProdutoEmEstoque += produto.QuantidadeProduto;
                }
            }
            else
                throw new System.ArgumentException("Pedido se encontra Aberto");
        }

        public void ValidaParcela()
        {
            if (TotalParcelas > 1)
            {
                TipoDeVenda = TipoDeVenda.Parcelado;
            }
            else if(TotalParcelas == 1)
            {
                TipoDeVenda = TipoDeVenda.Avista;
            }
            else
            {
                TipoDeVenda = TipoDeVenda.Invalido;
                throw new System.ArgumentException("Parcela com valor menor ou igual a Zero");
            }                
        }

        public void FaturarPedido()
        {
            ValidaParcela();

            if (statusDoPedido == StatusPedido.Faturar && TipoDeVenda != TipoDeVenda.Invalido)
            {
                if (TipoDeVenda == TipoDeVenda.Avista)
                    statusDoPedido = StatusPedido.Faturado;
                else
                {
                    if (Cliente.LimiteCredito >= ValorTotalPedido)
                    {
                        if (Cliente.TipoStatus != TipoStatusCliente.Ruim)
                        {
                            ValorParcelas = ValorTotalPedido / TotalParcelas;
                            statusDoPedido = StatusPedido.Faturado;
                        }
                        else
                        {
                            EstornaProdutoEstoque();
                            throw new System.ArgumentException("Parcelamento não aprovado");
                        }                            
                    }
                    else
                    {
                        EstornaProdutoEstoque();
                        throw new System.ArgumentException("Não possui limite de credito para efetuar o parcelamento");
                    }                        
                }
            }
            else
            {
                EstornaProdutoEstoque();
                throw new System.ArgumentException("O Pedido não está como status de Faturar");
            }                
        }

        public void CancelaPedido()
        {
            if (statusDoPedido != StatusPedido.Cancelado)
            {
                statusDoPedido = StatusPedido.Cancelado;
                EstornaProdutoEstoque();
            }
            else
                throw new System.ArgumentException("Produto já se encontra cancelado");
        }

        #endregion

    }
}
