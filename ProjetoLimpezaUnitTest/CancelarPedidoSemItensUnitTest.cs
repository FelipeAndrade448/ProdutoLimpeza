using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class CancelarPedidoSemItensUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void CancelarPedidoSemIten()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            var statusPedidoEsperado = ProdutoLimpeza.StatusPedido.Cancelado;

            pedido.CancelaPedido();

            Assert.AreEqual(statusPedidoEsperado, pedido.statusDoPedido);
        }
    }
}
