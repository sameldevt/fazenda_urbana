using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
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

        public override string ToString()
        {
            return $"Id: {ProducaoID}\nId do produto: {ProdutoID}\nId do fornecedor: {FornecedorID}\nQuantidade: {Quantidade}\n "
                + $"Data da produção: {DataProducao}\nData prevista para colheita: {DataPrevistaColheita}\nData da colheita: {DataColheita} " 
                + $"\nStatus: {Status}\nProduto: {Produto}\nFornecedor: {Fornecedor}";
        }
    }
}