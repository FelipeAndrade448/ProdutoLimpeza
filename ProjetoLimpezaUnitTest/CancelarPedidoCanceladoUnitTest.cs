using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class CancelarPedidoCanceladoUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void CancelarPedidoCancelado()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.AdicionaItemPedido();
            pedido.CancelaPedido();
            Assert.ThrowsException<ArgumentException>(() => { pedido.CancelaPedido(); }, "Produto já se encontra cancelado");
        }
    }
}
