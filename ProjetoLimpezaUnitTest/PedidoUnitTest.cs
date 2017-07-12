using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutoLimpeza;

namespace ProjetoLimpezaUnitTest
{
    [TestCategory("Pedido")]
    [TestClass]
    public class PedidoUnitTest
    {

        [TestCategory("Pedido")]
        [TestMethod]
        public void CalculaValorDoPedido()
        {
            Endereco EnderecoCliente = new Endereco()
            {
                Id = 8,
                Rua = "A",
                Numero = 6,
                Cidade = "Ibirite",
                Cep = "32400-000",
                Uf = "MG"
            };

            Endereco EnderecoFornecedor = new Endereco()
            {
                Id = 53,
                Rua = "Alameda",
                Numero = 65,
                Cidade = "Ibirite",
                Cep = "32400-000",
                Uf = "MG",
                Sala = "530D"
            };

            Cliente Cliente = new Cliente()
            {
                Id = 32,
                Nome = "João",
                Codigo = "C7758",
                Telefone = 319992240,
                Filiacao = "mae e pai",
                Cpf = "02365896587",
                Endereco = EnderecoCliente

            };

            Fornecedor Fornecedor = new Fornecedor()
            {
                Id = 2,
                Nome = "Triangulo Distribuidora",
                NomeFantasia = "YPE",
                Codigo = "FO23658",
                Telefone = 312569852,
                Endereco = EnderecoFornecedor
            };

            TipoCategoria TipoDeCategoria = new TipoCategoria()
            {
                Id = 25,
                Nome = "Detergente",
                Codigo = 2554
            };

            Produto Produto = new Produto()
            {
                Id = 28,
                Codigo = "PRO23658",
                Nome = "Detergente YPE",
                DataFabricacao = new DateTime(2017, 02, 01),
                DataVencimento = new DateTime(2017, 12, 31),
                Preco = 1.25,
                QuantidadeProduto = 200,
                TipoDeCategoria = TipoDeCategoria,
                Fornecedor = Fornecedor
            };

            Categoria categoria = new Categoria()
            {
                Id = 28,
                TipoDeCategoria = TipoDeCategoria
            };

            categoria.ListaDeProdutos.Add(Produto);

            Pedido pedido = new Pedido()
            {
                Id = 95,
                Codigo = "P63285",
                DataElaboracao = new DateTime(2017, 07, 07),
                QuantidadeProduto = 8,
                Cliente = Cliente,
            };
            pedido.Produtos.Add(Produto);

            //Método que efetua o Calculo
            pedido.CalculaValorTotalPedido(pedido);
            double valorEsperado = 10;

            Assert.AreEqual(valorEsperado, pedido.ValorTotal);
        }
    }
}
