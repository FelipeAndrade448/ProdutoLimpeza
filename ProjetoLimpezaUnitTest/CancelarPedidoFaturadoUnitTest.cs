using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class CancelarPedidoFaturadoUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void CancelarPedidoFaturado()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.AdicionaItemPedido();
            pedido.FaturarPedido();

            var statusPedidoEsperado = ProdutoLimpeza.StatusPedido.Cancelado;
            var estoqueProdutoEsperado = 200;

            pedido.CancelaPedido();

            Assert.AreEqual(statusPedidoEsperado, pedido.statusDoPedido);
            foreach (var produto in pedido.ItensPedido)
            {
                Assert.AreEqual(estoqueProdutoEsperado, produto.Produto.ProdutoEmEstoque);
            }
        }
    }
}
