using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class FaturamentoRuimComLimiteUnitTest
    {
        [TestCategory("Cliente")]
        [TestMethod]
        public void FaturamentoRuimComLimite()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.Cliente.TipoStatus = ProdutoLimpeza.TipoStatusCliente.Ruim;
            pedido.AdicionaItemPedido();

            Assert.ThrowsException<ArgumentException>(() => { pedido.FaturarPedido(); }, "Parcelamento não aprovado");
        }
    }
}
