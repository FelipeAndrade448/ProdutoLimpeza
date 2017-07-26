using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class FaturamentoClienteRuimSemLimiteUnitTest
    {
        [TestCategory("Cliente")]
        [TestMethod]
        public void FaturamentoClienteRuimSemLimiteCredito()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.Cliente.LimiteCredito = 0;
            pedido.Cliente.TipoStatus = ProdutoLimpeza.TipoStatusCliente.Ruim;
            pedido.AdicionaItemPedido();

            Assert.ThrowsException<ArgumentException>(() => { pedido.FaturarPedido(); }, "Não possui limite de credito para efetuar o parcelamento");
        }
    }
}
