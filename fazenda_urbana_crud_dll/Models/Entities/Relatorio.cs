using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
{
    public class Relatorio
    {
         public int RelatorioID { get; set; }
        public string TipoRelatorio { get; set; }
        public DateTime DataGeracao { get; set; }
        public string DadosRelatorio { get; set; }

        public override string ToString()
        {
            return $"Id: {RelatorioID}\nTipo do relatório: {TipoRelatorio}\nData de geração: {DataGeracao}\nDados relatório: {DadosRelatorio}";
        }
    }
}