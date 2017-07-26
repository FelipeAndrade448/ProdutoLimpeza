using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class FaturarProdutoZeradoOuNegativoUnitTest
    {
        [TestCategory("Produto")]
        [TestMethod]
        public void FaturarProdutoZeradoOuNegativo()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            foreach (var produto in pedido.ItensPedido)
            {
                produto.QuantidadeProduto = -80;

                Assert.ThrowsException<ArgumentException>(() => { produto.Produto.ValidaEstoque(produto.QuantidadeProduto); }, "Produto com quantidade Zero ou Negativo");
            }
        }
    }
}
