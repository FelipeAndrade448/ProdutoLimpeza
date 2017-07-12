using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutoLimpeza;

namespace ProjetoLimpezaUnitTest
{
    [TestClass]
    public class ValorVendaUnitTest
    {
        [TestCategory("Venda")]
        [TestMethod]
        public void CalcularVendas()
        {
            PreencherPedido pedidos = new PreencherPedido();           

            var pedido = pedidos.PreenchePedidos();
            var venda = pedidos.PreencheVenda(pedido);

            pedido.CalculaValorTotalPedido(pedido);
            venda.ValorTotalVenda(venda);

            var valorEsperado = 94;

            Assert.AreEqual(valorEsperado, venda.ValorTotal);
        }
    }
}
