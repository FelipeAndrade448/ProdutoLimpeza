using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoLimpeza
{
    public class Cliente : Pessoa
    {
        public int Id { get; set; }

        [Required]
        public string Filiacao { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public double LimiteCredito { get; set; }

        private TipoStatusCliente tipoStatus = TipoStatusCliente.Bom;

        public TipoStatusCliente TipoStatus
        {
            get
            {
                return tipoStatus;
            }
            set
            {
                tipoStatus = value;
            }
        }

        public List<Pedido> Pedidos = new List<Pedido>();       
    }
}
