using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
{
    public class Transporte
    {
        public int TransporteID { get; set; }
        public int VendaID { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime? DataEntrega { get; set; }
        public string Transportadora { get; set; }
        public string NumeroRastreamento { get; set; }
        public string Status { get; set; }
        public Venda Venda { get; set; }

        public override string ToString()
        {
            return $"Id: {TransporteID}\nTipo do relatório: {VendaID}\nData de geração: {DataEnvio}\nDados relatório: {DataEntrega}\n"
                    + $"Transportadora: {Transportadora}\nNumero de rastreamento: {NumeroRastreamento}\nStatus: {Status}\nVenda: {Venda}";
        }
    }
}