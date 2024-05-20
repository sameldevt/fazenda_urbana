using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
{
    public class Venda
    {
        public int VendaID { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public string MetodoPagamento { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetalheVenda> DetalhesVenda { get; set; }

        public override string ToString()
        {
            return $"Id: {VendaID}\nId do produto: {ClienteID}\nQuantidade: {DataVenda}\nData da última atualização: {ValorTotal}\nProduto: {MetodoPagamento}\n"
                    + $"Cliente: {Cliente}\nDetalhes da venda: {DetalhesVenda}";
        }
    }
}