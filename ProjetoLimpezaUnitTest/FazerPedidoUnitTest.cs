using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class FazerPedidoUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void FazerPedido()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.AdicionaItemPedido();

            var valorPedidoEsperado = 94;
            var totalProdutoEstoqueEsperado = 192;
            var totalProdutoPedidoEsperado = 16;

            foreach (var produto in pedido.ItensPedido)
            {
                Assert.AreEqual(totalProdutoEstoqueEsperado, produto.Produto.ProdutoEmEstoque);
            }

            Assert.AreEqual(valorPedidoEsperado, pedido.ValorTotalPedido);
            Assert.AreEqual(totalProdutoPedidoEsperado, pedido.TotalProdutosPedido);
        }
    }
}
