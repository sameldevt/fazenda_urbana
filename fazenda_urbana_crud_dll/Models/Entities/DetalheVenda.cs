using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
{
    public class DetalheVenda
    {
         public int DetalheVendaID { get; set; }
        public int VendaID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public Produto Produto { get; set; }

        public override string ToString()
        {
            return $"Id: {VendaID}\nProdutoID: {ProdutoID}\nQuantidade: {Quantidade}\nPrecoUnitario: {PrecoUnitario}\nProduto: {Produto}";
        }
    }
}