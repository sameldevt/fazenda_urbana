using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda.Models.Entities
{
    public class Producao
    {
         public int ProducaoID { get; set; }
        public int ProdutoID { get; set; }
        public int FornecedorID { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataProducao { get; set; }
        public DateTime? DataPrevistaColheita { get; set; }
        public DateTime? DataColheita { get; set; }
        public string Status { get; set; }
        public Produto Produto { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}