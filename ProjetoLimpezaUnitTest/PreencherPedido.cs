using ProdutoLimpeza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLimpezaUnitTest
{
    public class PreencherPedido
    {
        public Pedido PreenchePedidos()
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

            TipoCategoria TipoDeCategoria2 = new TipoCategoria()
            {
                Id = 24,
                Nome = "Sabão em Pó",
                Codigo = 2553
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

            Produto Produto2 = new Produto()
            {
                Id = 26,
                Codigo = "PRO23625",
                Nome = "Sabão em Pó OMO",
                DataFabricacao = new DateTime(2017, 02, 01),
                DataVencimento = new DateTime(2017, 12, 31),
                Preco = 10.50,
                QuantidadeProduto = 200,
                TipoDeCategoria = TipoDeCategoria2,
                Fornecedor = Fornecedor
            };


            Categoria categoria = new Categoria()
            {
                Id = 28,
                TipoDeCategoria = TipoDeCategoria
            };

            Categoria categoria2 = new Categoria()
            {
                Id = 25,
                TipoDeCategoria = TipoDeCategoria2
            };

            categoria.ListaDeProdutos.Add(Produto);
            categoria.ListaDeProdutos.Add(Produto2);

            Pedido pedido = new Pedido()
            {
                Id = 95,
                Codigo = "P63285",
                DataElaboracao = new DateTime(2017 - 07 - 07),
                QuantidadeProduto = 8,
                Cliente = Cliente,
            };
            pedido.Produtos.Add(Produto);
            pedido.Produtos.Add(Produto2);

            return pedido;
        } 

        public Venda PreencheVenda(Pedido pedido)
        {
            Venda venda = new Venda()
            {
                Id = 01,
                Codigo = "VE0001",
                DataVenda = new DateTime(2017 - 07 - 07),
                ValorTotal = 0
            };
            pedido.Cliente.Pedidos.Add(pedido);
            venda.Pedidos.Add(pedido);
            pedido.Cliente.Vendas.Add(venda);

            return venda;
        }
    }
}
