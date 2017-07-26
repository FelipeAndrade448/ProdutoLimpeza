using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class FaturarComParcelaZeroUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void FaturarComParcelaZero()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.TotalParcelas = 0;

            Assert.ThrowsException<ArgumentException>(() => { pedido.FaturarPedido(); }, "Parcela com valor menor ou igual a Zero");
        }
    }
}
