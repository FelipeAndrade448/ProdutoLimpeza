using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class FaturamentoPedidoCanceladoUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void FaturamentoPedidoCancelado()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.AdicionaItemPedido();
            pedido.CancelaPedido();

            Assert.ThrowsException<ArgumentException>(() => { pedido.FaturarPedido(); }, "O Pedido não está como status de Faturar");
        }
    }
}
