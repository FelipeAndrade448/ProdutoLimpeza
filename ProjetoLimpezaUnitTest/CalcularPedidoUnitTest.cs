using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutoLimpeza;

namespace ProjetoLimpezaUnitTest
{
    [TestCategory("Pedido")]
    [TestClass]
    public class CalcularPedidoUnitTest
    {

        [TestCategory("Pedido")]
        [TestMethod]
        public void CalculaValorDoPedido()
        {
            BaseTest basePedidos = new BaseTest();

            var pedido = basePedidos.PreenchePedidos();

            pedido.AdicionaItemPedido();

            double valorEsperado = 94;
            var totalProdutosEsperado = 16;

            Assert.AreEqual(valorEsperado, pedido.ValorTotalPedido);
            Assert.AreEqual(totalProdutosEsperado, pedido.TotalProdutosPedido);
        }
    }
}
