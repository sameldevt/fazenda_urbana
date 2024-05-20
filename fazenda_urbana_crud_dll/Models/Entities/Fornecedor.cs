using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
{
    public class Fornecedor
    {
        public int FornecedorID { get; set; }
        public string NomeFornecedor { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        public override string ToString()
        {
            return $"Id: {FornecedorID}\nNome: {NomeFornecedor}\nContato: {NomeContato}\nTelefone: {Telefone}\nEmail: {Email}\nEndereço: {Endereco}";
        }
    }
}