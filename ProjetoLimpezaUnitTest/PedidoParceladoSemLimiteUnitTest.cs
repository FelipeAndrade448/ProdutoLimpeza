using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class PedidoParceladoSemLimiteUnitTest
    {
        [TestCategory("Cliente")]
        [TestMethod]
        public void PedidoParceladoSemLimit()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.Cliente.LimiteCredito = 1000;

            foreach (var produto in pedido.ItensPedido)
            {
                produto.Produto.PrecoProduto = 250;
            }

            pedido.AdicionaItemPedido();

            Assert.ThrowsException<ArgumentException>(()=> { pedido.FaturarPedido(); }, "Não possui limite de credito para efetuar o parcelamento");
        }
    }
}
