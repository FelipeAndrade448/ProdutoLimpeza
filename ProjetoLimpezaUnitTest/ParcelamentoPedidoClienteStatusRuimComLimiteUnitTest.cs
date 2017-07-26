using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class ParcelamentoPedidoClienteStatusRuimComLimiteUnitTest
    {
        [TestCategory("Pedido")]
        [TestMethod]
        public void ParcelamentoPedidoClienteStatusRuimComLimite()
        {
            BaseTest baseTeste = new BaseTest();
            var pedido = baseTeste.PreenchePedidos();

            pedido.Cliente.TipoStatus = ProdutoLimpeza.TipoStatusCliente.Ruim;            

            Assert.ThrowsException<ArgumentException>(() => { pedido.FaturarPedido(); }, "Parcelamento não aprovado");
            
        }
    }
}
