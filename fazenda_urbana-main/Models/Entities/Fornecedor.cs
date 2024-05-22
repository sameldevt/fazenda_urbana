using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda.Models.Entities
{
    public class Fornecedor
    {
        public int FornecedorID { get; set; }
        public string NomeFornecedor { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}