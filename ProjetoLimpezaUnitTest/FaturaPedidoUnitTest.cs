using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutoLimpeza;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class FaturaPedidoUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void FaturarPedido()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.AdicionaItemPedido();
            pedido.FaturarPedido();

            var statusPedidoEsperado = StatusPedido.Faturado;
            var totalProdutosEsperado = 16;
            var valorTotalPedido = 94;

            Assert.AreEqual(statusPedidoEsperado, pedido.statusDoPedido);
            Assert.AreEqual(totalProdutosEsperado, pedido.TotalProdutosPedido);
            Assert.AreEqual(valorTotalPedido, pedido.ValorTotalPedido);

        }
    }
}
