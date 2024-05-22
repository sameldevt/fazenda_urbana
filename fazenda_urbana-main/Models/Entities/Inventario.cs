using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda.Models.Entities
{
    public class Inventario
    {
        public int InventarioID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public Produto Produto { get; set; }
    }
}