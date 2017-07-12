using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoLimpeza
{
    public class Categoria
    {
        public int Id { get; set; }

        public TipoCategoria TipoDeCategoria { get; set; }

        public List<Produto> ListaDeProdutos = new List<Produto>();
    }
}
