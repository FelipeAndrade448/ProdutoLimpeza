using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoLimpeza
{
    public class Endereco
    {
        public int Id { get; set; }

        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        [Required]
        public string Cep { get; set; }

        public string Uf { get; set; }     
    }
}
