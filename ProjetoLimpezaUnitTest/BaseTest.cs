using ProdutoLimpeza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLimpezaUnitTest
{
    public class BaseTest
    {
        public Pedido PreenchePedidos()
        {
            Endereco enderecoCliente = new Endereco()
            {
                Id = 8,
                Logradouro = "A",
                Numero = 6,
                Cidade = "Ibirite",
                Cep = "32400-000",
                Uf = "MG"
            };

            Endereco enderecoFornecedor = new Endereco()
            {
                Id = 53,
                Logradouro = "Alameda",
                Numero = 65,
                Cidade = "Ibirite",
                Cep = "32400-000",
                Uf = "MG",
                Complemento = "530D"
            };

            Cliente cliente = new Cliente()
            {
                Id = 32,
                Nome = "João",
                Codigo = "CI7758",
                Telefone = 319992240,
                Filiacao = "mae e pai",
                Cpf = "02365896587",
                LimiteCredito = 1000,
                Endereco = enderecoCliente,
                TipoStatus = TipoStatusCliente.Bom

            };

            Fornecedor fornecedor = new Fornecedor()
            {
                Id = 2,
                Nome = "Triangulo Distribuidora",
                NomeFantasia = "YPE",
                Codigo = "FO23658",
                Telefone = 312569852,
                Endereco = enderecoFornecedor
            };

            Categoria categoriaDetergente = new Categoria()
            {
                Id = 25,
                Nome = "Detergente",
                Codigo = "CA25636"
            };

            Categoria categoriaSabao = new Categoria()
            {
                Id = 24,
                Nome = "Sabão em Pó",
                Codigo = "CA236589"
            };

            Produto produtoDetergente = new Produto()
            {
                Id = 28,
                CodigoProduto = "PRO23658",
                Nome = "Detergente YPE",
                DataFabricacao = new DateTime(2017, 02, 01),
                DataVencimento = new DateTime(2017, 12, 31),
                PrecoProduto = 1.25,
                ProdutoEmEstoque = 200,
                Categoria = categoriaDetergente,
                Fornecedor = fornecedor
            };

            Produto produtoSabao = new Produto()
            {
                Id = 26,
                CodigoProduto = "PRO23625",
                Nome = "Sabão em Pó OMO",
                DataFabricacao = new DateTime(2017, 02, 01),
                DataVencimento = new DateTime(2017, 12, 31),
                PrecoProduto = 10.50,
                ProdutoEmEstoque = 200,
                Categoria = categoriaSabao,
                Fornecedor = fornecedor
            };

            ItemPedido itemPedidoDetergente = new ItemPedido()
            {
                Produto = produtoDetergente,
                QuantidadeProduto = 8
            };

            ItemPedido itemPedidoSabao = new ItemPedido()
            {
                Produto = produtoSabao,
                QuantidadeProduto = 8
            };

            Pedido pedido = new Pedido()
            {
                Id = 95,
                Codigo = "P63285",
                DataElaboracao = new DateTime(2017, 07, 07),
                TotalParcelas = 3,
                Cliente = cliente,              
            };
            pedido.ItensPedido.Add(itemPedidoDetergente);
            pedido.ItensPedido.Add(itemPedidoSabao);

            return pedido;
        } 
    }
}
