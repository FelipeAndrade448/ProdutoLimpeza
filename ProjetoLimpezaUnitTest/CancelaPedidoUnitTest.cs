using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutoLimpeza;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class CancelaPedidoUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void CancelarPedido()
        {
            BaseTest pedidos = new BaseTest();

            var pedido = pedidos.PreenchePedidos();

            pedido.AdicionaItemPedido();
            pedido.CancelaPedido();


            var statusEsperado = StatusPedido.Cancelado;
            var produtoEstoqueEsperado = 200;

            Assert.AreEqual(statusEsperado, pedido.statusDoPedido);

            foreach (var produto in pedido.ItensPedido)
            {
                Assert.AreEqual(produtoEstoqueEsperado, produto.Produto.ProdutoEmEstoque);
            }
        }
    }
}
