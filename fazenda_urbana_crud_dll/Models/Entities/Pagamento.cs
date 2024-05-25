using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
{
    public class Pagamento
    {
        public int PagamentoID { get; set; }
        public int VendaID { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public string MetodoPagamento { get; set; }
        public Venda Venda { get; set; }

        public override string ToString()
        {
            return $"Id: {PagamentoID}\nVendaID: {VendaID}\nDataPagamento: {DataPagamento}\nValorPagamento: {ValorPagamento}\nMetodoPagamento: {MetodoPagamento}\nVenda: {Venda}";
        }
    }
}