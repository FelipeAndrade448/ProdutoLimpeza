using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutoLimpeza;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class EfetuarVendaUnitTest
    {
        [TestCategory("Venda")]
        [TestMethod]
        public void EfeturarVenda()
        {
            PreencherPedido pedidos = new PreencherPedido();

            var pedido = pedidos.PreenchePedidos();
            var venda = pedidos.PreencheVenda(pedido);

            pedido.CalculaValorTotalPedido(pedido);
            venda.ValorTotalVenda(venda);

            venda.FaturaVenda(venda);

            var esperado = 94;
            var faturado = StatusVenda.Faturado;
            var quantidadeProduto = 192;

            Assert.AreEqual(esperado, venda.ValorTotal);
            Assert.AreEqual(faturado, venda.StatusVenda);

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
