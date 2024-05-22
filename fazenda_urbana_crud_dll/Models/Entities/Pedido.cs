using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
{
    public class Pedido
    {
        private long Id {get; set;}
        private List<Produto> Produtos {get; set;}
        private Cliente Cliente {get; set;}
        private DateTime DataPedido {get; set;}
        private decimal TotalPedido {get; set;}
        private string NumeroPedido {get; set;}
        private string MetodoPagamento {get; set;}

        public override string ToString()
        {
            return "";
        }
    }
}