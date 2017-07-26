using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class FaturarComPrecoZeroOuNegativoUnitTest
    {
        [TestCategory("Produto")]
        [TestMethod]
        public void FaturarComPrecoZeroOuNegativo()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            foreach (var produto in pedido.ItensPedido)
            {
                produto.Produto.PrecoProduto = -35;
            }

            Assert.ThrowsException<ArgumentException>(() => { pedido.AdicionaItemPedido(); }, "Produto com preço zero ou negativo");
        }
    }
}
