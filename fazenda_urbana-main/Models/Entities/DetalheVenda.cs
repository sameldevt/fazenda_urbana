using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda.Models.Entities
{
    public class DetalheVenda
    {
         public int DetalheVendaID { get; set; }
        public int VendaID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public Produto Produto { get; set; }
    }
}