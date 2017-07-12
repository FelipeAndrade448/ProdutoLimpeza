using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutoLimpeza;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class CancelaVendaUnitTest
    {
        [TestCategory("Venda")]
        [TestMethod]
        public void CancelarVenda()
        {
            PreencherPedido pedidos = new PreencherPedido();

            var pedido = pedidos.PreenchePedidos();
            var venda = pedidos.PreencheVenda(pedido);

            pedido.CalculaValorTotalPedido(pedido);
            venda.ValorTotalVenda(venda);
            venda.CancelaVenda(venda);

            var esperado = StatusVenda.Cancelado;
            var quantidadeProduto = 200;

            Assert.AreEqual(esperado, venda.StatusVenda);

            foreach (var pedidoVenda in venda.Pedidos)
            {
                foreach (var produto in pedidoVenda.Produtos)
                {
                    Assert.AreEqual(quantidadeProduto, produto.QuantidadeProduto);
                }
            }
        }
    }
}
