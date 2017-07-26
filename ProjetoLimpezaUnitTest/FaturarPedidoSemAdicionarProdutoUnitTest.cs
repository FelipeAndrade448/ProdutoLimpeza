using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class FaturarPedidoSemAdicionarProdutoUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void FaturarPedidoSemAdicionarProduto()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.Cliente.LimiteCredito = 0;
            pedido.Cliente.TipoStatus = ProdutoLimpeza.TipoStatusCliente.Ruim;

            Assert.ThrowsException<ArgumentException>(() => { pedido.FaturarPedido(); }, "O Pedido não está como status de Fatura");
        }
    }
}
